Imports Microsoft.VisualBasic
Imports DataAccessLayer
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data
Public Class Class1
    Public NotInheritable Class DBManagerFactory
        Private Sub New()
        End Sub
        Public Shared Function GetConnection(ByVal providerType As DataAccessLayer.DataProvider) As IDbConnection
            Dim iDbConnection As System.Data.IDbConnection = Nothing
            Select Case providerType
                Case DataProvider.SqlServer
                    iDbConnection = New SqlConnection()
                    Exit Select
                Case DataProvider.OleDb
                    iDbConnection = New OleDbConnection()
                    Exit Select
                Case DataProvider.Odbc
                    iDbConnection = New OdbcConnection()
                    Exit Select
                Case DataProvider.Oracle
                    ' iDbConnection = New OracleConnection()
                    Exit Select
                Case Else
                    Return Nothing
            End Select
            Return iDbConnection
        End Function

        Public Shared Function GetCommand(ByVal providerType As DataProvider) As IDbCommand
            Select Case providerType
                Case DataProvider.SqlServer
                    Return New SqlCommand()
                Case DataProvider.OleDb
                    Return New OleDbCommand()
                Case DataProvider.Odbc
                    Return New OdbcCommand()
                Case DataProvider.Oracle
                    'Return New OracleCommand()
                Case Else
                    Return Nothing
            End Select

        End Function

        Public Shared Function GetDataAdapter(ByVal providerType As DataProvider) As IDbDataAdapter
            Select Case providerType
                Case DataProvider.SqlServer
                    Return New SqlDataAdapter()
                Case DataProvider.OleDb
                    Return New OleDbDataAdapter()
                Case DataProvider.Odbc
                    Return New OdbcDataAdapter()
                Case DataProvider.Oracle
                    'Return New OracleDataAdapter()
                Case Else
                    Return Nothing
            End Select
        End Function
        Public Shared Function GetDataReader(ByVal providerType As DataProvider) As IDataReader
            Dim iDbConnection As System.Data.IDataReader = Nothing
            Select Case providerType
                Case DataProvider.SqlServer
                    Dim dr As SqlDataReader
                    iDbConnection = dr
                Case DataProvider.OleDb
                    Dim dr As OleDbDataReader
                    iDbConnection = dr
                    Return New OleDbDataAdapter()
                Case DataProvider.Odbc
                    Return New OdbcDataAdapter()
                Case DataProvider.Oracle
                    'Return New OracleDataAdapter()
                Case Else
                    Return Nothing
            End Select
            Return iDbConnection
        End Function
       

        Public Shared Function GetTransaction(ByVal providerType As DataProvider, ByVal conn As IDbConnection) As IDbTransaction
            'Dim iDbConnection As System.Data.IDbConnection = GetConnection(providerType)
            Dim iDbTransaction As System.Data.IDbTransaction = conn.BeginTransaction(IsolationLevel.Serializable)
            Return iDbTransaction
        End Function


        Public Shared Function GetParameter(ByVal providerType As DataProvider) As IDataParameter
            Dim iDataParameter As System.Data.IDataParameter = Nothing
            Select Case providerType
                Case DataProvider.SqlServer
                    iDataParameter = New SqlParameter()
                    Exit Select
                Case DataProvider.OleDb
                    iDataParameter = New OleDbParameter()
                    Exit Select
                Case DataProvider.Odbc
                    iDataParameter = New OdbcParameter()
                    Exit Select
                Case DataProvider.Oracle
                    ' iDataParameter = newOracleParameter()
                    Exit Select

            End Select
            Return iDataParameter
        End Function
        

        Public Shared Function GetParameters(ByVal providerType As DataProvider, ByVal paramsCount As Integer) As System.Data.IDbDataParameter()
            'Dim idbParams As System.Data.IDbDataParameter = New IDGetParameter(providerType)
            Dim idbParams As IDbDataParameter() = New IDbDataParameter(paramsCount - 1) {}

            Select Case providerType
                Case DataProvider.SqlServer
                    For i As Integer = 0 To paramsCount - 1
                        idbParams(i) = New SqlParameter()

                    Next
                    Exit Select
                Case DataProvider.OleDb
                    For i As Integer = 0 To paramsCount - 1
                        idbParams(i) = New OleDbParameter()

                    Next
                    Exit Select
                Case DataProvider.Odbc
                    For i As Integer = 0 To paramsCount - 1
                        idbParams(i) = New OdbcParameter()
                    Next
                    Exit Select
                Case DataProvider.Oracle
                    'For i As Integer = 0 To intParamsLength - 1
                    '    idbParams(i) = newOracleParameter()
                    'Next
                    'Exit Select
                Case Else
                    idbParams = Nothing
                    Exit Select
            End Select
            Return idbParams
        End Function
    End Class

End Class
