#include "pch.h"



#define SPIKEDECL extern "C" __declspec(dllexport)

#pragma pack(1)



// public static extern int Add_ReturnValue( int op1, int op2 );
SPIKEDECL int Add_ReturnValue( int op1, int op2 )
{
    return op1 + op2;
}



struct AddingStruct
{
    int op1;
    float op2;
    double sum;
};

SPIKEDECL void Add_InOutStruct( AddingStruct* data )
{
    data->sum = data->op1 + (int) data->op2;
}


SPIKEDECL void String_ToUpper( char* string, int length )
{
    while (length--)
        if (std::islower( *string++ ))
            string[-1] -= 32;
}


SPIKEDECL int String_charPtr( char* msg )
{
    int retval = 0;
    for (int i = 0; msg[i]; i++)
        retval += msg[i];
    return retval;
}


struct AddArrayStruct
{
    int len;
    float data[32];
};

SPIKEDECL double Struct_ArrayIn( AddArrayStruct info )
{
    double sum = 0;
    for (int i = 0; i < info.len; i++)
        sum += info.data[i];
    return sum;
}


SPIKEDECL double Array_Editable( float* array, int len )
{
    double sum = 0;

    for (int i = 0; i < len; i++)
    {
        array[i] -= 10;
        sum += array[i];
    }
    return sum;
}

struct AddFromArrayPtr
{
    int len;
    int *arr;
};

SPIKEDECL int Array_PtrInStruct( AddFromArrayPtr info )
{
    int sum = 0;

    for (int i = 0; i <info.len ; i++)
        sum += info.arr[i];

    return sum;

}