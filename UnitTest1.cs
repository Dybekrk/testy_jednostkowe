using System;
using Xunit;

public class TriangleTests
{
    // Funkcja sprawdzaj�ca, czy z podanych d�ugo�ci bok�w mo�na utworzy� tr�jk�t
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

    // Testy dla przypadk�w, gdzie tr�jk�t powinien by� utworzony
    [Fact]
    public void TestValidTriangle()
    {
        Assert.True(CanFormTriangle(3, 4, 5)); // Tr�jk�t prostok�tny
        Assert.True(CanFormTriangle(6, 8, 10)); // Tr�jk�t prostok�tny
        Assert.True(CanFormTriangle(5, 12, 13)); // Tr�jk�t prostok�tny
        Assert.True(CanFormTriangle(7, 8, 9)); // Tr�jk�t o r�nych bokach
        Assert.True(CanFormTriangle(10, 20, 25)); // Zwyk�y tr�jk�t o wi�kszych bokach
    }

    // Testy dla przypadk�w, gdzie tr�jk�t nie mo�e by� utworzony
    [Fact]
    public void TestInvalidTriangle()
    {
        Assert.False(CanFormTriangle(1, 1, 3)); // Suma dw�ch mniejszych bok�w nie jest wi�ksza od trzeciego
        Assert.False(CanFormTriangle(0, 2, 3)); // Jeden z bok�w ma warto�� zero
        Assert.False(CanFormTriangle(-1, 2, 3)); // Jeden z bok�w ma warto�� ujemn�
        Assert.False(CanFormTriangle(10, 10, 30)); // Zbyt du�a r�nica w bokach
    }

    // Testy kraw�dziowe
    [Fact]
    public void TestEdgeCases()
    {
        Assert.False(CanFormTriangle(1, 2, 3)); // Suma dw�ch mniejszych bok�w nie jest wi�ksza od trzeciego
        Assert.False(CanFormTriangle(2, 2, 5)); // Tr�jk�t nie mo�e istnie�, poniewa� 2 + 2 <= 5
        Assert.True(CanFormTriangle(2, 2, 3)); // Tr�jk�t r�wnoramienny, kt�ry mo�e istnie�
    }

    // Testy dla przypadk�w, gdzie boki maj� takie same warto�ci
    [Fact]
    public void TestEquilateralTriangle()
    {
        Assert.True(CanFormTriangle(5, 5, 5)); // Tr�jk�t r�wnoboczny
        Assert.True(CanFormTriangle(100, 100, 100)); // Tr�jk�t r�wnoboczny o du�ych bokach
    }

    // Testy dla warto�ci bardzo du�ych
    [Fact]
    public void TestLargeNumbers()
    {
        Assert.True(CanFormTriangle(1_000_000, 1_000_000, 1_000_000)); // Bardzo du�y tr�jk�t r�wnoboczny
        Assert.False(CanFormTriangle(1_000_000, 2_000_000, 3_000_000)); // Suma dw�ch mniejszych bok�w nie jest wi�ksza od trzeciego
    }
}
