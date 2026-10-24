#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <stdint.h>
#include <wchar.h>
#include <stdio.h>
#include <stdarg.h>

static FILE *launch_log = NULL;
static wchar_t player_log[32768];

static void log_line(const wchar_t *format, ...) {
    if (!launch_log) return;
    va_list args;
    va_start(args, format);
    vfwprintf(launch_log, format, args);
    va_end(args);
    fputwc(L'\n', launch_log);
    fflush(launch_log);
}

static void initialize_log(void) {
    wchar_t appdata[32768], directory[32768], filename[32768];
    DWORD length = GetEnvironmentVariableW(L"LOCALAPPDATA", appdata, 32768);
    if (!length || length >= 32768) return;
    if (swprintf_s(directory, 32768, L"%ls\\ZoneMotionPC", appdata) < 0) return;
    if (!CreateDirectoryW(directory, NULL) && GetLastError() != ERROR_ALREADY_EXISTS) return;
    if (swprintf_s(filename, 32768, L"%ls\\last-launch.txt", directory) < 0) return;
    if (swprintf_s(player_log, 32768, L"%ls\\Player.log", directory) < 0) return;
    _wfopen_s(&launch_log, filename, L"w, ccs=UTF-8");
    log_line(L"Zone Motion Windows launcher 0.1.1");
}

typedef struct {
    uint32_t type;
    const void *next;
    const char *app_name;
    uint32_t app_version;
    const char *engine_name;
    uint32_t engine_version;
    uint32_t api_version;
} VkAppInfo;

typedef struct {
    uint32_t type;
    const void *next;
    uint32_t flags;
    const VkAppInfo *app;
    uint32_t layer_count;
    const char *const *layers;
    uint32_t extension_count;
    const char *const *extensions;
} VkInstanceInfo;

typedef int32_t (WINAPI *CreateVkInstance)(const VkInstanceInfo *, const void *, void **);
typedef int32_t (WINAPI *EnumerateVkDevices)(void *, uint32_t *, void *);
typedef void (WINAPI *DestroyVkInstance)(void *, const void *);

static int has_vulkan_device(const wchar_t *loader_path) {
    HMODULE loader = LoadLibraryW(loader_path);
    if (!loader) return 0;
#pragma warning(push)
#pragma warning(disable: 4191)
    CreateVkInstance create = (CreateVkInstance)GetProcAddress(loader, "vkCreateInstance");
    EnumerateVkDevices enumerate = (EnumerateVkDevices)GetProcAddress(loader, "vkEnumeratePhysicalDevices");
    DestroyVkInstance destroy = (DestroyVkInstance)GetProcAddress(loader, "vkDestroyInstance");
#pragma warning(pop)
    int available = 0;
    if (create && enumerate && destroy) {
        VkAppInfo app = {0, NULL, "Zone Motion", 1, "Unity", 1, 1u << 22};
        VkInstanceInfo info = {1, NULL, 0, &app, 0, NULL, 0, NULL};
        void *instance = NULL;
        if (create(&info, NULL, &instance) == 0) {
            uint32_t count = 0;
            available = enumerate(instance, &count, NULL) == 0 && count > 0;
            destroy(instance, NULL);
        }
    }
    FreeLibrary(loader);
    return available;
}

static int fail(const wchar_t *message) {
    log_line(L"ERROR: %ls (Windows error %lu)", message, GetLastError());
    if (launch_log) { fclose(launch_log); launch_log = NULL; }
    MessageBoxW(NULL, message, L"Zone Motion", MB_ICONERROR | MB_OK);
    return 1;
}

int WINAPI wWinMain(HINSTANCE app, HINSTANCE previous, PWSTR arguments, int show) {
    (void)app; (void)previous; (void)show;
    initialize_log();
    wchar_t root[32768], game[32768], executable[32768], loader[32768], driver[32768];
    DWORD length = GetModuleFileNameW(NULL, root, 32768);
    if (!length || length >= 32768) return fail(L"Не удалось определить папку игры.");
    wchar_t *slash = wcsrchr(root, L'\\');
    if (!slash) return fail(L"Не удалось определить папку игры.");
    *slash = 0;
    log_line(L"Payload: %ls", root);
    if (swprintf_s(game, 32768, L"%ls\\Game", root) < 0 ||
        swprintf_s(executable, 32768, L"%ls\\ZoneMotionPC.exe", game) < 0 ||
        swprintf_s(loader, 32768, L"%ls\\vulkan-1.dll", game) < 0 ||
        swprintf_s(driver, 32768, L"%ls\\SoftwareRenderer\\vk_swiftshader_icd.json", game) < 0)
        return fail(L"Слишком длинный путь к игре.");
    if (GetFileAttributesW(executable) == INVALID_FILE_ATTRIBUTES)
        return fail(L"Файлы игры не найдены. Распакуйте весь архив и запустите ZoneMotion.exe.");
    SetDllDirectoryW(game);
    /* Use the same software path verified by the Windows game checks by
       default; old Unity Vulkan initialization can fail on newer GPU drivers. */
    int hardware_requested = wcsstr(arguments, L"--hardware-renderer") != NULL;
    log_line(L"Hardware renderer requested: %d", hardware_requested);
    if (!hardware_requested || !has_vulkan_device(loader)) {
        if (GetFileAttributesW(driver) == INVALID_FILE_ATTRIBUTES)
            return fail(L"Файлы графического модуля не найдены. Распакуйте весь архив игры.");
        if (!SetEnvironmentVariableW(L"VK_ICD_FILENAMES", driver))
            return fail(L"Не удалось настроить графический модуль игры.");
        log_line(L"Renderer: bundled compatible software Vulkan");
    } else {
        log_line(L"Renderer: hardware Vulkan");
    }
    wchar_t command[32768];
    int has_log_argument = wcsstr(arguments, L"-logFile") != NULL || wcsstr(arguments, L"-logfile") != NULL;
    int command_length;
    if (!has_log_argument && player_log[0])
        command_length = swprintf_s(command, 32768, L"\"%ls\" -force-vulkan -logFile \"%ls\" %ls", executable, player_log, arguments);
    else
        command_length = swprintf_s(command, 32768, L"\"%ls\" -force-vulkan %ls", executable, arguments);
    if (command_length < 0)
        return fail(L"Слишком длинная команда запуска.");
    STARTUPINFOW startup;
    PROCESS_INFORMATION process;
    ZeroMemory(&startup, sizeof(startup));
    ZeroMemory(&process, sizeof(process));
    startup.cb = sizeof(startup);
    if (!CreateProcessW(executable, command, NULL, NULL, FALSE, 0, NULL, game, &startup, &process))
        return fail(L"Не удалось запустить игру. Проверьте, что весь архив распакован в одну папку.");
    log_line(L"Game process started: %lu", process.dwProcessId);
    CloseHandle(process.hThread);
    WaitForSingleObject(process.hProcess, INFINITE);
    DWORD result = 1;
    GetExitCodeProcess(process.hProcess, &result);
    log_line(L"Game exit code: %lu (0x%08lX)", result, result);
    CloseHandle(process.hProcess);
    if (launch_log) fclose(launch_log);
    return (int)result;
}
