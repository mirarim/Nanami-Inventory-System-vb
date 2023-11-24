
Public Class delete4

    Dim strQuery = ""
    ''for login
    Private Sub login_Click(sender As Object, e As EventArgs) Handles login.Click
        If user.Text = "eurus" And pass.Text = "@pr0m1s3123" Then
            GroupBox1.Visible = False

        Else

            MessageBox.Show("Password entered is Incorrect!")

            user.Clear()
            pass.Clear()
            user.Focus()

        End If


    End Sub
    '' for clear
    Public Sub clearfields()

        '' clear for table 1  customer details

        txtcustid.Clear()
        txtcustname.Clear()
        productidb.Clear()
        orderid.Clear()
        txtcustadd.Clear()
        txtcustconnum.Clear()
        txtvat.Clear()
        txtcountry.Clear()
        txtbal.Clear()

        '' clear for table 2  New customer

        Entry.Clear()
        customeridcust.Clear()
        discount.Clear()
        adddisc.Clear()
        deftax.Clear()
        curr.Clear()
        dept.Clear()
        comment.Clear()
        anal.Clear()
        addinfo.Clear()



        '' claer  product

        prodid.Clear()
        prodname.Clear()
        ver.Clear()
        performance.Clear()
        color.Clear()
        datearrive.Clear()
        price.Clear()


        '' clear order

        orderidmain.Clear()
        productidorder.Clear()
        orderdate.Clear()
        shipment.Clear()
        ordernum.Clear()
        quantity.Clear()
        orderprice.Clear()




    End Sub
    '' for tables
    Public Sub prodprocess()
        SQLManager(strQuery)
        _displayRecords("select*from customer_det", customer_det)
        _displayRecords("select*from new_customer", newcustomer)
        _displayRecords("select*from product", prodgrid)
        _displayRecords("select*from order_det", ordergrid)

    End Sub
    '' for record display

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dbConnection()

        _displayRecords("select*from customer_det", customer_det)
        _displayRecords("select*from new_customer", newcustomer)
        _displayRecords("select*from product", prodgrid)
        _displayRecords("select*from order_det", ordergrid)

        '' combo box display

        _loadtocombostatus("select*from status_t", statuscombo)
        _loadtocomboware("select*from warehouse_address", warehousecombo)
        _loadtocombometh("select*from payment_method", paymentmeth)

    End Sub

    '''''''''''''''''''


    '' TABLE 2
    '' FOR TABLE 2

    '' For new customer
    Private Sub newcustomer_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles newcustomer.CellClick

        Dim i = e.RowIndex

        With newcustomer

            Entry.Text = .Item("entry", i).Value
            customeridcust.Text = .Item("customer_id", i).Value
            discount.Text = .Item("discount", i).Value
            adddisc.Text = .Item("additional_discount", i).Value
            deftax.Text = .Item("Def_Tax_Cod", i).Value
            curr.Text = .Item("currency", i).Value
            dept.Text = .Item("department", i).Value
            comment.Text = .Item("comment", i).Value
            anal.Text = .Item("analysis", i).Value
            addinfo.Text = .Item("additional_info", i).Value


        End With

    End Sub


    '' for add 2



    Private Sub add2_Click(sender As Object, e As EventArgs) Handles add2.Click

        strQuery = "insert into new_customer values(" & Entry.Text & "," & discount.Text & ", " & customeridcust.Text & ", " & adddisc.Text & ", " & deftax.Text & ", '" & curr.Text & "', '" & dept.Text & "',  '" & comment.Text & "', '" & anal.Text & "', '" & addinfo.Text & "');"
        MessageBox.Show("Records Successfully Stored.")
        prodprocess()

    End Sub


    '' for update 2


    Private Sub update2_Click(sender As Object, e As EventArgs) Handles update2.Click

        strQuery = "update new_customer set discount=" & discount.Text & ", customer_id=" & customeridcust.Text & ", additional_discount=" & adddisc.Text & ", Def_Tax_Cod=" & deftax.Text & ", currency='" & curr.Text & "', department='" & dept.Text & "', comment='" & comment.Text & "', analysis='" & anal.Text & "', additional_info='" & addinfo.Text & "' where entry=" & Entry.Text & "; "
        MessageBox.Show("Table Successfully Updated.")
        prodprocess()

    End Sub

    '' for clear 2


    Private Sub clear2_Click(sender As Object, e As EventArgs) Handles clear2.Click

        clearfields()

    End Sub

    '' for delete 2


    Private Sub del2_Click(sender As Object, e As EventArgs) Handles del2.Click

        strQuery = "delete from new_customer where entry=" & Entry.Text & ";"
        MessageBox.Show("Record Successfully Deleted.")
        prodprocess()

    End Sub
    ''''''''''''''''''''



    '' for customer details cell click
    Private Sub customer_det_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles customer_det.CellClick

        Dim i = e.RowIndex

        With customer_det

            txtcustid.Text = .Item("customer_id", i).Value
            txtcustname.Text = .Item("customer_name", i).Value
            productidb.Text = .Item("product_id_bought", i).Value
            orderid.Text = .Item("order_id", i).Value
            txtcustadd.Text = .Item("address", i).Value
            txtcustconnum.Text = .Item("contact_number", i).Value
            statuscombo.SelectedValue = .Item("status", i).Value
            txtvat.Text = .Item("VAT_number", i).Value
            txtcountry.Text = .Item("country", i).Value
            txtbal.Text = .Item("balance", i).Value


        End With

    End Sub


    '' for add
    Private Sub add1_Click(sender As Object, e As EventArgs) Handles add1.Click

        strQuery = "insert into customer_det values(" & txtcustid.Text & ", '" & txtcustname.Text & "', " & productidb.Text & ", " & orderid.Text & ", '" & txtcustadd.Text & "', " & statuscombo.SelectedValue & ", " & txtcustconnum.Text & ",  " & txtvat.Text & ", '" & txtcountry.Text & "', " & txtbal.Text & ");"
        MessageBox.Show("Records Successfully Stored.")
        prodprocess()


    End Sub

    '' for search

    Private Sub search_TextChanged(sender As Object, e As EventArgs) Handles search.TextChanged

        strQuery = "select*from customer_det where customer_id like '%" & search.Text & "%' or customer_name like '%" & search.Text & "%' or address like '%" & search.Text & "%'"
        _displayRecords(strQuery, customer_det)

    End Sub

    '' for save/update

    Private Sub update1_Click(sender As Object, e As EventArgs) Handles update1.Click

        strQuery = "update customer_det set customer_name='" & txtcustname.Text & "', product_id_bought=" & productidb.Text & ", order_id= " & orderid.Text & ", address='" & txtcustadd.Text & "', contact_number=" & txtcustconnum.Text & ", status=" & statuscombo.SelectedValue & ", VAT_number=" & txtvat.Text & ", country='" & txtcountry.Text & "', balance=" & txtbal.Text & " where customer_id=" & txtcustid.Text & " ; "
        MessageBox.Show("Table Successfully Updated.")
        prodprocess()

    End Sub

    '' for clear
    Private Sub clear1_Click(sender As Object, e As EventArgs) Handles clear1.Click

        clearfields()

    End Sub
    '' for delete

    Private Sub del1_Click(sender As Object, e As EventArgs) Handles del1.Click

        strQuery = "delete from customer_det where customer_id=" & txtcustid.Text & ";"
        MessageBox.Show("Record Successfully Deleted.")
        prodprocess()

    End Sub








    '' for product


    '''''''''''''''''
    '' FOR TABLE 3


    Private Sub prodgrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles prodgrid.CellClick

        Dim i = e.RowIndex

        With prodgrid

            prodid.Text = .Item("product_id", i).Value
            prodname.Text = .Item("product_name", i).Value
            ver.Text = .Item("version", i).Value
            performance.Text = .Item("performance", i).Value
            color.Text = .Item("color", i).Value
            datearrive.Text = .Item("date_of_arrival", i).Value
            warehousecombo.SelectedValue = .Item("warehouse", i).Value
            price.Text = .Item("price", i).Value

        End With

    End Sub

    '' for add 3

    Private Sub add3_Click(sender As Object, e As EventArgs) Handles add3.Click

        strQuery = "insert into product values(" & prodid.Text & ",'" & prodname.Text & "', '" & ver.Text & "', '" & performance.Text & "', '" & color.Text & "', '" & datearrive.Text & "', " & warehousecombo.SelectedValue & ", " & price.Text & " );"
        MessageBox.Show("Records Successfully Stored.")
        prodprocess()

    End Sub

    '' for update 3

    Private Sub update3_Click(sender As Object, e As EventArgs) Handles update3.Click

        strQuery = "update product set product_name='" & prodname.Text & "', version='" & ver.Text & "', performance='" & performance.Text & "', color='" & color.Text & "', date_of_arrival='" & datearrive.Text & "', warehouse= " & warehousecombo.SelectedValue & ",price=" & price.Text & " where product_id=" & prodid.Text & "; "
        MessageBox.Show("Table Successfully Updated.")
        prodprocess()

    End Sub

    '' for clear 3

    Private Sub clear3_Click(sender As Object, e As EventArgs) Handles clear3.Click

        clearfields()

    End Sub

    '' for delete 3

    Private Sub delete3_Click(sender As Object, e As EventArgs) Handles delete3.Click

        strQuery = "delete from product where product_id=" & prodid.Text & ";"
        MessageBox.Show("Record Successfully Deleted.")
        prodprocess()

    End Sub


    '' for search product


    Private Sub prodsearch_TextChanged(sender As Object, e As EventArgs) Handles prodsearch.TextChanged

        strQuery = "select*from product where product_id like '%" & prodsearch.Text & "%' or product_name like '%" & prodsearch.Text & "%' or version like '%" & prodsearch.Text & "%'"
        _displayRecords(strQuery, prodgrid)

    End Sub



    '' for table 4 order details

    Private Sub ordergrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ordergrid.CellClick

        Dim i = e.RowIndex

        With ordergrid

            orderidmain.Text = .Item("order_id", i).Value
            productidorder.Text = .Item("product_id", i).Value
            orderdate.Text = .Item("order_date", i).Value
            shipment.Text = .Item("shipment_fee", i).Value
            paymentmeth.SelectedValue = .Item("payment_method", i).Value
            ordernum.Text = .Item("order_number", i).Value
            quantity.Text = .Item("quantity", i).Value
            orderprice.Text = .Item("price", i).Value

        End With

    End Sub




    '' for add 4

    Private Sub add4_Click(sender As Object, e As EventArgs) Handles add4.Click

        strQuery = "insert into order_det values(" & orderidmain.Text & ",'" & productidorder.Text & "', '" & orderdate.Text & "', " & shipment.Text & ", " & paymentmeth.SelectedValue & ", " & ordernum.Text & ", " & quantity.Text & ", " & orderprice.Text & " );"
        MessageBox.Show("Records Successfully Stored.")
        prodprocess()

    End Sub


    '' for update 4

    Private Sub update4_Click(sender As Object, e As EventArgs) Handles update4.Click

        strQuery = "update order_det set product_id=" & productidorder.Text & ", order_date='" & orderdate.Text & "', shipment_fee=" & shipment.Text & ", payment_method=" & paymentmeth.SelectedValue & ", order_number=" & ordernum.Text & ", quantity= " & quantity.Text & ", price=" & orderprice.Text & " where order_id=" & orderidmain.Text & "; "
        MessageBox.Show("Table Successfully Updated.")
        prodprocess()

    End Sub

    '' for clear 4

    Private Sub clear4_Click(sender As Object, e As EventArgs) Handles clear4.Click

        clearfields()

    End Sub

    '' for delete 4

    Private Sub del4_Click(sender As Object, e As EventArgs) Handles del4.Click

        strQuery = "delete from order_det where order_id=" & orderidmain.Text & ";"
        MessageBox.Show("Record Successfully Deleted.")
        prodprocess()

    End Sub

End Class
