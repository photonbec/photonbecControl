// FlyCapture2CameraControlNativeExport.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
#include "FlyCapture2CameraControlNativeExport.h"


#ifdef _MANAGED
#pragma managed(push, off)
#endif

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
					 )
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
    return TRUE;
}

#ifdef _MANAGED
#pragma managed(pop)
#endif

// This is an example of an exported variable
FC2EXPORT_API int nFlyCapture2CameraControlNativeExport=0;

// This is an example of an exported function.
FC2EXPORT_API int fnFlyCapture2CameraControlNativeExport(void)
{
	return 42;
}

// This is the constructor of a class that has been exported.
// see FlyCapture2CameraControlNativeExport.h for the class definition
CFlyCapture2CameraControlNativeExport::CFlyCapture2CameraControlNativeExport()
{
	return;
}
