// DecryptionProgram.cpp : Pretends to decrypt files by copying them into place
//
#include "stdafx.h"
#include "Shlwapi.h"

#include <cassert>
#include <comutil.h>
#include <direct.h>
#include <fstream>
#include <iostream>
#include <shlobj.h>
#include <stdio.h>
#include <string>
#include <windows.h>
#include <winerror.h>

#pragma comment(lib, "comsuppw")
#pragma warning(disable: 4996)

using namespace std;


int _tmain(int argc, _TCHAR* argv[])
{
	// Get desktop path
	wchar_t* desktopPath = 0;
	HRESULT hr = SHGetKnownFolderPath(FOLDERID_Desktop, 0, nullptr, &desktopPath);

	if (SUCCEEDED(hr))
	{
		// Try to create the GlobeComm directory
		_bstr_t bstrPath(desktopPath);
		_bstr_t globecommPath = bstrPath + "\\GlobeComm Deliveries";
		_bstr_t downloadsPath = globecommPath + "\\Downloads";
		if (CreateDirectory(globecommPath, NULL) ||	ERROR_ALREADY_EXISTS == GetLastError())
		{
			if (CreateDirectory(downloadsPath, NULL) || ERROR_ALREADY_EXISTS == GetLastError())
			{
				// Get current path to files
				char buffer[MAX_PATH];
				_getcwd(buffer, MAX_PATH);
				string strPath(buffer);

				_bstr_t currPath = strPath.c_str();
				_bstr_t inPath1 = currPath + "\\Experimental_Error.pdf";
				_bstr_t inPath2 = currPath + "\\Tech_Analysis.pdf";
				_bstr_t inPath3 = currPath + "\\Resources_request.pdf";

				// Get resulting path to files
				_bstr_t outPath1 = downloadsPath + "\\Experimental_Error.pdf";
				_bstr_t outPath2 = downloadsPath + "\\Tech_Analysis.pdf";
				_bstr_t outPath3 = downloadsPath + "\\Resources_Request.pdf";

				// Print pretend decryption message
				cout << "Decrypting\n";
				for (int i = 0; i < 50; i++)
				{
				cout << ".";
				Sleep(100);
				}
				cout << "\n";

				// Copy files
				if (	CopyFile(inPath1, outPath1, false)
					&&	CopyFile(inPath2, outPath2, false)
					&&	CopyFile(inPath3, outPath3, false))
				{
					cout << "Decryption Successful\n";
					Sleep(2000);
				}
				else
				{
					cout << "Err: failed to copy files.";
					Sleep(10000);
				}

			}
			else
			{
				cout << "Err: failed to create directory " << downloadsPath;
				Sleep(10000);
			}
		}
		else
		{
			cout << "Err: failed to create directory " << globecommPath;
			Sleep(10000);
		}
	}
}

