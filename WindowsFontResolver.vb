Imports PdfSharp.Fonts
Imports System.IO

Public Class WindowsFontResolver
    Implements PdfSharp.Fonts.IFontResolver

    Public Function ResolveTypeface(familyName As String, isBold As Boolean, isItalic As Boolean) As FontResolverInfo Implements PdfSharp.Fonts.IFontResolver.ResolveTypeface
        ' Map common font families to their system file names
        Dim baseName As String = familyName.ToLower()

        If baseName = "arial" Then
            If isBold AndAlso isItalic Then
                Return New FontResolverInfo("arialbi.ttf")
            ElseIf isBold Then
                Return New FontResolverInfo("arialbd.ttf")
            ElseIf isItalic Then
                Return New FontResolverInfo("ariali.ttf")
            Else
                Return New FontResolverInfo("arial.ttf")
            End If
        End If

        ' Fallback for other fonts (optional)
        Throw New InvalidOperationException($"Font '{familyName}' is not supported by this custom resolver.")
    End Function

    Public Function GetFont(faceName As String) As Byte() Implements PdfSharp.Fonts.IFontResolver.GetFont
        ' Load the font file from the Windows Fonts folder
        Dim fontPath As String = Path.Combine("C:\Windows\Fonts", faceName)

        If File.Exists(fontPath) Then
            Return File.ReadAllBytes(fontPath)
        Else
            Throw New FileNotFoundException($"The font file '{fontPath}' was not found.")
        End If
    End Function
End Class