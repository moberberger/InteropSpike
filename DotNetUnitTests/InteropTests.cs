using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class InteropTests
{
    [TestMethod]
    public void Add_ReturnValue()
    {
        Assert.AreEqual( 42, DLL.Add_ReturnValue( 19, 23 ) );
    }



    [TestMethod]
    public void Add_InOutStruct()
    {
        var info = new AddingStruct();
        info.op1 = 19;
        info.op2 = 23;
        DLL.Add_InOutStruct( info );
        Assert.AreEqual( 42.0, info.sum );
    }



    [TestMethod]
    public void String_ToUpper()
    {
        const string someString = "Bad to the Bone!";

        StringBuilder msg = new( someString );

        DLL.String_ToUpper( msg, msg.Length );

        Assert.AreEqual( someString.ToUpper(), msg.ToString() );
    }


    [TestMethod]
    public void String_stdString()
    {
        const string str = "abcdefghijkl";

        var expected = str.Sum( ch => (int)ch );
        var actual = DLL.String_charPtr( str );

        Assert.AreEqual( expected, actual );
    }


    [TestMethod]
    public void Struct_ArrayIn()
    {
        AddArrayStruct info = new()
        {
            len = 5,
            data = new float[] { 1f, 2f, 3f, 4f, 5f },
        };

        // 
        // v v v v v v
        // 
        Array.Resize( ref info.data, 32 );
        // 
        // ^ ^ ^ ^ ^ ^
        // 


        var expected = info.data.Sum();
        var actual = DLL.Struct_ArrayIn( info );

        Assert.AreEqual( expected, actual );
    }



    [TestMethod]
    public void Array_Editable()
    {
        var arr = new float[] { 10, 11, 12, 13, 14, 15 };

        var oldSum = arr.Select( x => x - 10f ).Sum();
        var actual = DLL.Array_Editable( arr, arr.Length );

        Assert.AreEqual( oldSum, actual );

        var newSum = arr.Sum();
        Assert.AreEqual( newSum, actual );
    }



}


[StructLayout( LayoutKind.Sequential, Pack = 0 )]
public class AddingStruct
{
    public int op1;
    public float op2;
    public double sum;
};


[StructLayout( LayoutKind.Sequential, Pack = 0 )]
public class AddArrayStruct
{
    public int len;

    [MarshalAs( UnmanagedType.ByValArray, SizeConst = 32 )]
    public float[] data;
};

