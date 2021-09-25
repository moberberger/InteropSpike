﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public static class DLL
{
    [DllImport( @"CPP_DLL.dll", ExactSpelling = true, SetLastError = true )]
    public static extern int Add_ReturnValue( int op1, int op2 );


    [DllImport( @"CPP_DLL.dll", ExactSpelling = true, SetLastError = true )]
    public static extern int Add_InOutStruct( AddingStruct info );


    [DllImport( @"CPP_DLL.dll", ExactSpelling = true, SetLastError = true )]
    public static extern void String_ToUpper( StringBuilder str, int len );


    [DllImport( @"CPP_DLL.dll", ExactSpelling = true, SetLastError = true )]
    public static extern int String_charPtr( string msg );


    [DllImport( @"CPP_DLL.dll", ExactSpelling = true, SetLastError = true )]
    public static extern double Struct_ArrayIn( AddArrayStruct info );


    [DllImport( @"CPP_DLL.dll", ExactSpelling = true, SetLastError = true )]
    public static extern double Array_Editable( float[] data, int len );


}
