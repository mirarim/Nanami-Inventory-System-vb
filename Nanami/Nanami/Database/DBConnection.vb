Imports MySql.Data.MySqlClient

Module DBConnection
    Dim sqlConn As MySqlConnection
    Dim sqlCommand As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim dt As DataTable



    Private strConn = "server=localhost; username=root; database=nanami; port=3306"

    Public Sub _dbConnection()

        Try

            sqlConn = New MySqlConnection(strConn)
            MessageBox.Show("Connection Successful")
            sqlConn.Open()

        Catch ex As Exception

            MessageBox.Show("Connection Failed" & ex.Message)

        Finally

            sqlConn.Close()

        End Try

    End Sub

    Public Sub _displayRecords(ByVal SQL As String, ByVal DG As DataGridView)
        Try

            da = New MySqlDataAdapter(SQL, sqlConn)
            dt = New DataTable
            da.Fill(dt)
            DG.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Records Failed to Show " & ex.Message)
        Finally
            sqlConn.Close()
        End Try

    End Sub

    '' for combo box status

    Public Sub _loadtocombostatus(ByVal SQL As String, ByVal cbostat As ComboBox)
        Try

            da = New MySqlDataAdapter(SQL, sqlConn)
            dt = New DataTable
            da.Fill(dt)
            cbostat.DataSource = dt
            cbostat.ValueMember = dt.Columns(0).ToString
            cbostat.DisplayMember = dt.Columns(1).ToString

        Catch ex As Exception
            MessageBox.Show("Status Combo Box Fail " & ex.Message)
        Finally
            sqlConn.Close()
        End Try

    End Sub

    '' for combobox warehouse

    Public Sub _loadtocomboware(ByVal SQL As String, ByVal cboware As ComboBox)
        Try

            da = New MySqlDataAdapter(SQL, sqlConn)
            dt = New DataTable
            da.Fill(dt)
            cboware.DataSource = dt
            cboware.ValueMember = dt.Columns(0).ToString
            cboware.DisplayMember = dt.Columns(1).ToString

        Catch ex As Exception
            MessageBox.Show("Status Combo Box Fail " & ex.Message)
        Finally
            sqlConn.Close()
        End Try

    End Sub


    '' combo box payment method

    Public Sub _loadtocombometh(ByVal SQL As String, ByVal cbometh As ComboBox)
        Try

            da = New MySqlDataAdapter(SQL, sqlConn)
            dt = New DataTable
            da.Fill(dt)
            cbometh.DataSource = dt
            cbometh.ValueMember = dt.Columns(0).ToString
            cbometh.DisplayMember = dt.Columns(1).ToString

        Catch ex As Exception
            MessageBox.Show("Status Combo Box Fail " & ex.Message)
        Finally
            sqlConn.Close()
        End Try

    End Sub

    '' connetion test

    Public Sub SQLManager(ByVal SQL As String)
        Try
            sqlConn.Open()
            sqlCommand = New MySqlCommand(SQL, sqlConn)

            With sqlCommand

                .CommandType = CommandType.Text
                .ExecuteNonQuery()

            End With

        Catch ex As Exception
            MessageBox.Show("SQL Manager Fail " & ex.Message)

        Finally
            sqlConn.Close()

        End Try

    End Sub


End Module