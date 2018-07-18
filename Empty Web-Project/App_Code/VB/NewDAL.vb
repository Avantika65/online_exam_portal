Imports Microsoft.VisualBasic
Imports DataAccessLayer
Imports System.Data
Imports Class1
Imports System.Configuration.ConfigurationManager
Imports System.Data.Common
Imports System
Namespace NewDAL
    Public NotInheritable Class DBManager
        Implements DataAccessLayer.IDBManager
        ' DBManager' must implement 'Function ExecuteNonQuery(commandType As System.Data.CommandType, commandText As String) As Integer' for interface 'DataAccessLayer.IDBManager'.	D:\Inetpub\wwwroot\Education\App_Code\DataLayer\Class2.vb	7	20	D:\...\Education\

        'Implements System.IDisposable

        Private idbConnection As IDbConnection
        Private idataReader As IDataReader
        Private idbCommand As IDbCommand
        Private m_providerType As DataProvider
        Private idbTransaction As IDbTransaction = Nothing
        Private idbParameters As IDbDataParameter() = Nothing
        Private strConnection As String
        Private Dbtype As OleDb.OleDbType
        Private pd As ParameterDirection
        Private _getD As String
        Private _getDI As Integer
        Public Overloads Sub DBManager()

        End Sub
        Public Overloads Sub DBManager(ByVal providerType As DataProvider)
            Me.m_providerType = providerType
        End Sub

        Public Overloads Sub DBManager(ByVal providerType As DataProvider, ByVal connectionString As String)
            Me.m_providerType = providerType
            'If providerType = DataProvider.OleDb Then
            '    Me.strConnection = ConnectionStrings("PortalConnectionString").ConnectionString()
            'Else
            Me.strConnection = connectionString 'ConnectionStrings("FeesManagementConn").ConnectionString()
            'End If
        End Sub

        Public ReadOnly Property Connection() As IDbConnection Implements DataAccessLayer.IDBManager.Connection
            Get
                Return idbConnection
            End Get
        End Property

        Public Property DataReader() As IDataReader Implements DataAccessLayer.IDBManager.DataReader
            Get
                Return idataReader
            End Get
            Set(ByVal value As IDataReader)
                idataReader = value
            End Set
        End Property
        Public Property GetD() As String Implements DataAccessLayer.IDBManager.GetDetail
            Get
                Return _getD
            End Get
            Set(ByVal value As String)
                _getD = value
            End Set
        End Property
        Public Property GetDI() As Integer Implements DataAccessLayer.IDBManager.GetDetailI
            Get
                Return _getDI
            End Get
            Set(ByVal value As Integer)
                _getDI = value
            End Set
        End Property

        Public Property ProviderType() As DataProvider Implements DataAccessLayer.IDBManager.ProviderType
            Get
                Return m_providerType
            End Get
            Set(ByVal value As DataProvider)
                m_providerType = value
            End Set
        End Property

        Public Property ConnectionString() As String Implements DataAccessLayer.IDBManager.ConnectionString
            Get
                Return strConnection
            End Get
            Set(ByVal value As String)
                strConnection = value
            End Set
        End Property

        Public ReadOnly Property Command() As IDbCommand Implements DataAccessLayer.IDBManager.Command
            Get
                Return idbCommand
            End Get
        End Property

        Public ReadOnly Property Transaction() As IDbTransaction Implements DataAccessLayer.IDBManager.Transaction
            Get
                Return idbTransaction
            End Get
        End Property

        Public ReadOnly Property Parameters() As IDbDataParameter() Implements DataAccessLayer.IDBManager.Parameters
            Get
                Return idbParameters
            End Get
        End Property
        Public ReadOnly Property Dbtypeo() As DbType Implements DataAccessLayer.IDBManager.DBtype
            Get
                Return Dbtype
            End Get
        End Property
        Public ReadOnly Property p() As ParameterDirection Implements DataAccessLayer.IDBManager.p
            Get
                Return pd
            End Get
        End Property

        Public Sub Open() Implements DataAccessLayer.IDBManager.Open
            idbConnection = DBManagerFactory.GetConnection(Me.m_providerType)
            idbConnection.ConnectionString = Me.ConnectionString
            If idbConnection.State <> ConnectionState.Open Then
                idbConnection.Open()
            End If
            idbCommand = DBManagerFactory.GetCommand(Me.ProviderType)
        End Sub

        Public Sub Close() Implements DataAccessLayer.IDBManager.Close
            If idbConnection.State <> ConnectionState.Closed Then
                idbConnection.Close()
                Me.Close()

            End If
        End Sub
        Public Function Get_Detail(ByVal str As String) As String Implements DataAccessLayer.IDBManager.Get_Detail
            Dim objDb As New DBManager
            Dim retVal As String = String.Empty
            Try
                objDb.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("FeesManagementConn").ConnectionString
                objDb.DBManager(DataAccessLayer.DataProvider.SqlServer, objDb.ConnectionString)
                objDb.Open()
                idbCommand = DBManagerFactory.GetCommand(DataProvider.SqlServer)
                PrepareCommand(idbCommand, Connection, Transaction, CommandType.Text, str, Parameters)
                Dim dataAdapter As IDbDataAdapter = DBManagerFactory.GetDataAdapter(DataProvider.SqlServer)
                dataAdapter.SelectCommand = idbCommand
                dataAdapter.SelectCommand.Connection = objDb.Connection
                Dim dataSet As New DataSet
                dataAdapter.Fill(dataSet)
                idbCommand.Parameters.Clear()
                Dim dt As DataTable = dataSet.Tables(0)
                If dt.Rows.Count > 0 Then
                    GetD = dt.Rows(0).ItemArray(0).ToString()
                End If
            Catch ex As Exception
                GetD = DataAccessLayer.IsError.Yes
            End Try
            Return GetD
        End Function
        Public Function Get_Detail(ByVal str As String, ByVal ty As Int16) As Integer Implements DataAccessLayer.IDBManager.Get_DetailI
            Dim objDb As New DBManager
            Dim retVal As Integer = 0
            Try
                objDb.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("FeesManagementConn").ConnectionString
                objDb.DBManager(DataAccessLayer.DataProvider.SqlServer, objDb.ConnectionString)
                objDb.Open()
                idbCommand = DBManagerFactory.GetCommand(ProviderType)
                PrepareCommand(idbCommand, Connection, Transaction, CommandType.Text, str, Parameters)
                Dim dataAdapter As IDbDataAdapter = DBManagerFactory.GetDataAdapter(ProviderType)
                dataAdapter.SelectCommand = idbCommand
                dataAdapter.SelectCommand.Connection = objDb.Connection
                Dim dataSet As New DataSet
                dataAdapter.Fill(dataSet)
                idbCommand.Parameters.Clear()
                Dim dt As DataTable = dataSet.Tables(0)
                If dt.Rows.Count > 0 Then
                    GetDI = Convert.ToInt64(dt.Rows(0).ItemArray(0).ToString())
                End If
            Catch ex As Exception
                GetDI = DataAccessLayer.IsError.Yes
            End Try
            Return GetDI
        End Function
        'Public Sub Dispose() Implements System.IDisposable.Dispose
        '    'GC.SupressFinalize(Me)
        '    Me.Close()
        '    Me.idbCommand = Nothing
        '    Me.idbTransaction = Nothing
        '    Me.idbConnection = Nothing
        'End Sub
        Public Overloads Sub Dispose() Implements DataAccessLayer.IDBManager.Dispose
            GC.SuppressFinalize(Me)
            Me.Close()
            Me.idbCommand = Nothing
            Me.idbTransaction = Nothing
            Me.idbConnection = Nothing
        End Sub
        Public Sub CreateParameters(ByVal paramsCount As Integer) Implements DataAccessLayer.IDBManager.CreateParameters
            'idbParameter = New DBManagerFactory.GetParameters(paramsCount)
            idbParameters = DBManagerFactory.GetParameters(ProviderType, paramsCount)

            ' DBManagerFactory.GetParameter(DataProvider.OleDb)
        End Sub
        Public Enum DbType2
            BigInt
            Binary
            Bool
            BSTR
            Chr
            Currency
            Datee
            DBDate
            DBTime
            DBTimeStamp
            Decimall
            Double1
            Empty
            Err
            LongVarBinary
            LongVarChar
            LongVarWChar
            Numeric
            Singl
            SmallInt
            TinyInt
            VarBinary
            VarChar
            VarNumeric
            VarWChar
            WChar
        End Enum
        Public Sub AddParameters(ByVal index As Integer, ByVal paramName As String, ByVal objValue As Object, ByVal dbtype As DbType) Implements DataAccessLayer.IDBManager.AddParameters
            If index < idbParameters.Length Then
                idbParameters(index).ParameterName = "@" & paramName
                idbParameters(index).Value = objValue
                idbParameters(index).DbType = dbtype
            End If
        End Sub
        Public Sub AddParameters(ByVal index As Integer, ByVal paramName As String, ByVal objValue As Object, ByVal dbtype As DbType, ByVal p As ParameterDirection) Implements DataAccessLayer.IDBManager.AddParameters
            If index < idbParameters.Length Then
                idbParameters(index).ParameterName = "@" & paramName
                idbParameters(index).Value = objValue
                idbParameters(index).Direction = p
                idbParameters(index).DbType = dbtype
            End If
        End Sub
        Public Sub AddParametersout(ByVal index As Integer, ByVal paramName As String, ByVal objValue As Object, ByVal dbtype As DbType, Optional ByVal par As Object = Nothing) Implements DataAccessLayer.IDBManager.AddParametersout
            If index < idbParameters.Length Then
                idbParameters(index).ParameterName = "@" & paramName
                If (par(index).ToString = "O") Then
                    idbParameters(index).Direction = ParameterDirection.Output
                Else
                    idbParameters(index).Direction = ParameterDirection.Input
                End If
                idbParameters(index).Value = objValue
                idbParameters(index).DbType = dbtype
            End If
        End Sub

        Public Sub BeginTransaction() Implements DataAccessLayer.IDBManager.BeginTransaction
            If Me.idbTransaction Is Nothing Then
                idbTransaction = DBManagerFactory.GetTransaction(Me.ProviderType, Me.Connection)

            End If
            idbCommand = DBManagerFactory.GetCommand(Me.ProviderType)
            idbCommand.Connection = Me.Connection
            idbCommand.Transaction = idbTransaction

        End Sub

        Public Sub CommitTransaction() Implements DataAccessLayer.IDBManager.CommitTransaction
            If Me.idbTransaction IsNot Nothing Then
                Me.idbTransaction.Commit()
            End If
            idbTransaction = Nothing
        End Sub

        Public Function ExecuteReader(ByVal commandType As CommandType, ByVal commandText As String) As IDataReader Implements DataAccessLayer.IDBManager.ExecuteReader
            Me.idbCommand = DBManagerFactory.GetCommand(Me.ProviderType)
            idbCommand.Connection = Me.Connection
            PrepareCommand(idbCommand, Me.Connection, Me.Transaction, commandType, commandText, Me.Parameters)
            Me.DataReader = idbCommand.ExecuteReader()
            idbCommand.Parameters.Clear()
            Return Me.DataReader
        End Function

        Public Sub CloseReader() Implements DataAccessLayer.IDBManager.CloseReader
            If Me.DataReader IsNot Nothing Then
                Me.DataReader.Close()
            End If
        End Sub

        Private Sub AttachParameters(ByVal IDbCommandcommand As IDbCommand, ByVal commandParameters As IDbDataParameter()) 'Implements DataAccessLayer.IDBManager.CreateParameters
            For Each idbParameter As IDbDataParameter In commandParameters
                If (idbParameter.Direction = ParameterDirection.InputOutput) AndAlso (idbParameter.Value Is Nothing) Then
                    idbParameter.Value = System.DBNull.Value

                End If
                If (idbParameter.Direction = ParameterDirection.Output) Then
                    idbParameter.Size = 50

                End If
                IDbCommandcommand.Parameters.Add(idbParameter)
            Next
        End Sub

        Private Sub PrepareCommand(ByVal IDbCommandcommand As IDbCommand, ByVal connection As IDbConnection, ByVal transaction As IDbTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal commandParameters As IDbDataParameter())
            Command.Connection = connection
            Command.CommandText = commandText
            Command.CommandType = commandType
            If transaction IsNot Nothing Then
                Command.Transaction = transaction
            End If
            If commandParameters IsNot Nothing Then
                AttachParameters(Command, commandParameters)
            End If
        End Sub

        Public Function ExecuteNonQuery(ByVal commandType As CommandType, ByVal commandText As String) As Integer Implements DataAccessLayer.IDBManager.ExecuteNonQuery
            Me.idbCommand = DBManagerFactory.GetCommand(ProviderType)
            idbCommand.UpdatedRowSource = UpdateRowSource.Both
            PrepareCommand(idbCommand, Connection, Transaction, commandType, commandText, Parameters)
            idbCommand.Prepare()
            Dim returnValue As Integer = idbCommand.ExecuteNonQuery()
            'Dim i As Integer
            'For i = 0 To Parameters.Length - 1
            '    If Parameters(i).Direction = ParameterDirection.Output Then
            '        returnValue = Parameters(i).Value.ToString()
            '    End If
            'Next
            idbCommand.Parameters.Clear()

            Return returnValue
           
           
        End Function

        Public Function ExecuteNonQueryHR(ByVal commandType As CommandType, ByVal commandText As String) As Integer Implements DataAccessLayer.IDBManager.ExecuteNonQueryHR
            Me.idbCommand = DBManagerFactory.GetCommand(ProviderType)
            idbCommand.UpdatedRowSource = UpdateRowSource.Both
            PrepareCommand(idbCommand, Connection, Transaction, commandType, commandText, Parameters)
            idbCommand.Prepare()
            Dim returnValue As Integer = idbCommand.ExecuteNonQuery()
            'Dim i As Integer
            'For i = 0 To Parameters.Length - 1
            '    If Parameters(i).Direction = ParameterDirection.Output Then
            '        returnValue = Parameters(i).Value.ToString()
            '    End If
            'Next
            'idbCommand.Parameters.Clear()

            Return returnValue


        End Function
        'Private Shared Function DiscoverProcedureParameterSet(ByVal connection As IDbConnection, ByVal procedureName As String, ByVal returnValueParameter As Boolean) As OleDbParameter()


        '    OleDbCommandBuilder.DeriveParameters(sqlCmd)
        '    If Not returnValueParameter Then
        '        sqlCmd.Parameters.RemoveAt(0)
        '    End If
        '    Dim discoveredParameters As OleDbParameter() = New OleDbParameter(sqlCmd.Parameters.Count - 1) {}


        '    sqlCmd.Parameters.CopyTo(discoveredParameters, 0)
        '    Return discoveredParameters

        'End Function

        Public Function ExecuteScalar(ByVal commandType As CommandType, ByVal commandText As String) As Object Implements DataAccessLayer.IDBManager.ExecuteScalar

            Me.idbCommand = DBManagerFactory.GetCommand(ProviderType)
            PrepareCommand(idbCommand, Connection, Transaction, commandType, commandText, Me.Parameters)
            Dim returnValue As Object = idbCommand.ExecuteScalar()
            idbCommand.Parameters.Clear()
            Return returnValue




        End Function
        Public Function ExecuteDataSet(ByVal commandType As CommandType, ByVal commandText As String) As DataSet Implements DataAccessLayer.IDBManager.ExecuteDataSet
            Me.idbCommand = DBManagerFactory.GetCommand(Me.ProviderType)
            PrepareCommand(idbCommand, Me.Connection, Me.Transaction, commandType, commandText, Me.Parameters)
            Dim dataAdapter As DbDataAdapter = DBManagerFactory.GetDataAdapter(Me.ProviderType)
            dataAdapter.SelectCommand = idbCommand
            Dim dataSet As New DataSet()
            dataAdapter.Fill(dataSet)
            idbCommand.Parameters.Clear()
            Return dataSet
        End Function
        'Public Function ExecuteDataSet(ByVal commandType As CommandType, ByVal commandText As String) As DataSet Implements DataAccessLayer.IDBManager.ExecuteDataSet
        '    Me.idbCommand = DBManagerFactory.GetCommand(Me.ProviderType)
        '    PrepareCommand(idbCommand, Me.Connection, Me.Transaction, commandType, commandText, Me.Parameters)
        '    Dim dataAdapter As IDbDataAdapter = DBManagerFactory.GetDataAdapter(Me.ProviderType)
        '    dataAdapter.SelectCommand = idbCommand
        '    Dim dataSet As New DataSet()
        '    dataAdapter.Fill(dataSet)
        '    idbCommand.Parameters.Clear()
        '    Return dataSet
        'End Function

        Public Function ExecuteTable(ByVal commandType As CommandType, ByVal commandText As String) As DataTable Implements DataAccessLayer.IDBManager.ExecuteTable
            idbCommand = DBManagerFactory.GetCommand(ProviderType)
            PrepareCommand(idbCommand, Connection, Transaction, commandType, commandText, Parameters)
            Dim dataAdapter As IDbDataAdapter = DBManagerFactory.GetDataAdapter(ProviderType)
            dataAdapter.SelectCommand = idbCommand
            Dim dataSet As New DataSet
            dataAdapter.Fill(dataSet)
            idbCommand.Parameters.Clear()
            Dim dt As DataTable = dataSet.Tables(0)
            Return dt
        End Function
    End Class

End Namespace
