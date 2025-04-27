using System;
using Xunit;

public class TriangleTests
{
    // Funkcja sprawdzaj¹ca, czy z podanych d³ugoœci boków mo¿na utworzyæ trójk¹t
    public bool CanFormTriangle(int a, int b, int c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
        {
            return false;
        }
        if (a + b > c && a + c > b && b + c > a)
        {
            return true;
        }
        return false;
    }

    // Testy dla przypadków, gdzie trójk¹t powinien byæ utworzony
    [Fact]
    public void TestValidTriangle()
    {
        Assert.True(CanFormTriangle(3, 4, 5)); // Trójk¹t prostok¹tny
        Assert.True(CanFormTriangle(6, 8, 10)); // Trójk¹t prostok¹tny
        Assert.True(CanFormTriangle(5, 12, 13)); // Trójk¹t prostok¹tny
        Assert.True(CanFormTriangle(7, 8, 9)); // Trójk¹t o ró¿nych bokach
        Assert.True(CanFormTriangle(10, 20, 25)); // Zwyk³y trójk¹t o wiêkszych bokach
    }

    // Testy dla przypadków, gdzie trójk¹t nie mo¿e byæ utworzony
    [Fact]
    public void TestInvalidTriangle()
    {
        Assert.False(CanFormTriangle(1, 1, 3)); // Suma dwóch mniejszych boków nie jest wiêksza od trzeciego
        Assert.False(CanFormTriangle(0, 2, 3)); // Jeden z boków ma wartoœæ zero
        Assert.False(CanFormTriangle(-1, 2, 3)); // Jeden z boków ma wartoœæ ujemn¹
        Assert.False(CanFormTriangle(10, 10, 30)); // Zbyt du¿a ró¿nica w bokach
    }

    // Testy krawêdziowe
    [Fact]
    public void TestEdgeCases()
    {
        Assert.False(CanFormTriangle(1, 2, 3)); // Suma dwóch mniejszych boków nie jest wiêksza od trzeciego
        Assert.False(CanFormTriangle(2, 2, 5)); // Trójk¹t nie mo¿e istnieæ, poniewa¿ 2 + 2 <= 5
        Assert.True(CanFormTriangle(2, 2, 3)); // Trójk¹t równoramienny, który mo¿e istnieæ
    }

    // Testy dla przypadków, gdzie boki maj¹ takie same wartoœci
    [Fact]
    public void TestEquilateralTriangle()
    {
        Assert.True(CanFormTriangle(5, 5, 5)); // Trójk¹t równoboczny
        Assert.True(CanFormTriangle(100, 100, 100)); // Trójk¹t równoboczny o du¿ych bokach
    }

    // Testy dla wartoœci bardzo du¿ych
    [Fact]
    public void TestLargeNumbers()
    {
        Assert.True(CanFormTriangle(1_000_000, 1_000_000, 1_000_000)); // Bardzo du¿y trójk¹t równoboczny
        Assert.False(CanFormTriangle(1_000_000, 2_000_000, 3_000_000)); // Suma dwóch mniejszych boków nie jest wiêksza od trzeciego
    }
}
