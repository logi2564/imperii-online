"""Small read/write adapter around StormLib, used only by the offline builder."""
import ctypes as c
import ctypes.util
import os
from pathlib import Path

P=c.c_void_p
U=c.c_uint32

class Storm:
    def __init__(self):
        name=os.environ.get('STORMLIB_PATH') or ctypes.util.find_library('storm') or '/workspace/warcraft-map-work/storm-build/libstorm.so'
        self.lib=c.CDLL(name)
        for method,types in {
            'SFileOpenArchive':[c.c_char_p,U,U,c.POINTER(P)],
            'SFileOpenFileEx':[P,c.c_char_p,U,c.POINTER(P)],
            'SFileGetFileSize':[P,c.POINTER(U)],
            'SFileReadFile':[P,P,U,c.POINTER(U),P],
            'SFileCloseFile':[P], 'SFileCloseArchive':[P],
            'SFileAddFileEx':[P,c.c_char_p,c.c_char_p,U,U,U],
        }.items():getattr(self.lib,method).argtypes=types
        self.lib.SFileGetFileSize.restype=U
    def open(self,path,readonly=True):
        handle=P()
        if not self.lib.SFileOpenArchive(os.fsencode(path),0,0x100 if readonly else 0,c.byref(handle)):raise OSError('Cannot open MPQ: '+str(path))
        return handle
    def read(self,handle,name):
        f=P()
        if not self.lib.SFileOpenFileEx(handle,name.encode(),0,c.byref(f)):return None
        try:
            size=self.lib.SFileGetFileSize(f,None)
            if size>64*1024*1024:raise ValueError('MPQ entry too large')
            data=c.create_string_buffer(size);read=U()
            if size and (not self.lib.SFileReadFile(f,data,size,c.byref(read),None) or read.value!=size):raise OSError('Read failed: '+name)
            return data.raw
        finally:self.lib.SFileCloseFile(f)
    def close(self,handle):
        if not self.lib.SFileCloseArchive(handle):raise OSError('Cannot close MPQ')
    def replace(self,path,entries,temp):
        handle=self.open(path,False)
        try:
            for index,(name,data) in enumerate(entries.items()):
                file=Path(temp)/str(index);file.write_bytes(data)
                if not self.lib.SFileAddFileEx(handle,os.fsencode(file),name.encode(),0x80000200,2,2):raise OSError('Cannot write MPQ entry: '+name)
        finally:self.close(handle)
