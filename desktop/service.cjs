const DISCOVERY_URL =
  "https://raw.githubusercontent.com/logi2564/imperii-online/svoi-release/service.json";

function serviceOrigin(value, { development = false } = {}) {
  if (typeof value !== "string" || value.length > 2048)
    throw Error("Invalid service configuration");
  const url = new URL(value);
  const local = ["127.0.0.1", "localhost", "[::1]"].includes(url.hostname);
  if (
    url.protocol !== "https:" &&
    !(development && local && url.protocol === "http:")
  )
    throw Error("The service must use HTTPS");
  if (
    url.username ||
    url.password ||
    url.pathname !== "/" ||
    url.search ||
    url.hash
  )
    throw Error("Expected a service origin");
  return url.origin;
}

async function checkedFetch(fetcher, url) {
  const response = await fetcher(url, {
    signal: AbortSignal.timeout(10000),
    cache: "no-store",
  });
  if (!response.ok) throw Error("Service unavailable");
  return response.json();
}

async function discover({
  fetcher,
  cached,
  developmentUrl,
  manifestUrl = DISCOVERY_URL,
}) {
  if (developmentUrl) {
    const origin = serviceOrigin(developmentUrl, { development: true });
    await checkHealth(fetcher, origin);
    return { phase: "ready", origin };
  }
  let config;
  try {
    config = await checkedFetch(fetcher, manifestUrl);
    if (config.schema !== 1) throw Error("Unknown manifest version");
  } catch (error) {
    if (!cached) throw error;
    const origin = serviceOrigin(cached);
    await checkHealth(fetcher, origin);
    return { phase: "ready", origin };
  }
  if (config.origin === null) return { phase: "not_deployed" };
  const origin = serviceOrigin(config.origin);
  await checkHealth(fetcher, origin);
  return { phase: "ready", origin };
}

async function checkHealth(fetcher, origin) {
  const health = await checkedFetch(fetcher, origin + "/health");
  if (!health.ok || health.app !== "svoi" || health.protocol !== 1)
    throw Error("The chat service is not ready");
}

module.exports = { DISCOVERY_URL, serviceOrigin, discover };
