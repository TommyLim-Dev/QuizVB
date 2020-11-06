Public Class Form1
    Dim dt As New DataTable
    Dim gender As String = String.Empty
    Private mintRowWeAreEditing As Integer = -1
    Private Sub reload()
        Try
            ComboBox1.Items.Clear()
            ComboBox1.Items.Add("Aktif")
            ComboBox1.Items.Add("Tidak AKtif")
            Button1.Text = "New"
            Button2.Text = "Edit"
            Button3.Text = "Close"
            TextBox1.Text = ""
            ComboBox2.Text = ""
            ComboBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            ComboBox1.Text = " "
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            MaskedTextBox1.Text = ""
            TextBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox7.Enabled = False
            TextBox8.Enabled = False
            TextBox9.Enabled = False
            ComboBox1.Enabled = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            MaskedTextBox1.Enabled = False
            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = True
            DataGridView1.Enabled = True
            DataGridView1.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox7.Select()
        dt.Columns.Add("ID Karyawan", GetType(Integer))
        dt.Columns.Add("Nama Karyawan", GetType(String))
        dt.Columns.Add("Department", GetType(String))
        dt.Columns.Add("Level Karyawan", GetType(String))
        dt.Columns.Add("Gaji Pokok", GetType(Integer))
        dt.Columns.Add("Potongan", GetType(Integer))
        dt.Columns.Add("Periode", GetType(String))
        dt.Columns.Add("Gaji Bersih", GetType(String))
        dt.Columns.Add("Jenis Kelamin", GetType(String))
        dt.Columns.Add("Lama Bekerja", GetType(Integer))
        dt.Columns.Add("Status", GetType(String))
        reload()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            DataGridView1.Enabled = False

            If Button1.Text = "Save" Then
                If ComboBox1.Text <> "" AndAlso ComboBox2.Text <> "" AndAlso ComboBox3.Text <> "" AndAlso TextBox1.Text <> "" AndAlso TextBox4.Text <> "" AndAlso TextBox5.Text <> "" AndAlso TextBox7.Text <> "" Then
                    DataGridView1.ReadOnly = False
                    If RadioButton1.Checked = True Then
                        gender = "Laki-Laki"
                    ElseIf RadioButton2.Checked = True Then
                        gender = "Perempuan"
                    Else
                        gender = " "
                    End If
                    dt.Rows.Add(TextBox7.Text, TextBox1.Text, ComboBox2.Text, ComboBox3.Text, TextBox8.Text, TextBox9.Text, TextBox5.Text, MaskedTextBox1.Text, gender, TextBox4.Text, ComboBox1.Text)
                    DataGridView1.DataSource = dt
                    reload()
                    Return
                End If

            Else
                MessageBox.Show("Fill All Form to Proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            If Button1.Text = "New" Then
                MaskedTextBox1.Enabled = True
                TextBox1.Enabled = True
                ComboBox2.Enabled = True
                ComboBox3.Enabled = True
                TextBox4.Enabled = True
                TextBox5.Enabled = True
                TextBox7.Enabled = True
                TextBox8.Enabled = False
                TextBox9.Enabled = True
                ComboBox1.Enabled = True
                RadioButton1.Enabled = True
                RadioButton2.Enabled = True
                Button1.Enabled = True
                Button2.Enabled = False
                Button3.Text = "Cancel"
                Button1.Text = "Save"
                DataGridView1.Enabled = False
                TextBox1.Text = ""
                ComboBox2.Text = ""
                ComboBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                ComboBox1.Text = " "
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If Button2.Text = "Save" Then
                Dim drw As DataRow = DirectCast(DataGridView1.Rows(mintRowWeAreEditing).DataBoundItem, DataRowView).Row
                drw("ID Karyawan") = TextBox7.Text
                drw("Nama Karyawan") = TextBox1.Text
                drw("Department") = ComboBox2.Text
                drw("Level Karyawan") = ComboBox3.Text
                drw("Gaji Pokok") = TextBox8.Text
                drw("Potongan") = TextBox9.Text
                drw("Gaji Bersih") = TextBox5.Text
                drw("Periode") = MaskedTextBox1.Text
                drw("Jenis Kelamin") = gender
                drw("Lama Bekerja") = TextBox4.Text
                drw("Status") = ComboBox1.Text
                reload()
                Return
            End If


            If Button2.Text = "Edit" Then
                mintRowWeAreEditing = DataGridView1.CurrentCell.RowIndex
                MaskedTextBox1.Enabled = True
                TextBox1.Enabled = True
                ComboBox2.Enabled = True
                ComboBox3.Enabled = True
                TextBox4.Enabled = True
                TextBox5.Enabled = True
                TextBox7.Enabled = True
                TextBox8.Enabled = False
                TextBox9.Enabled = True
                ComboBox1.Enabled = True
                RadioButton1.Enabled = True
                RadioButton2.Enabled = True
                Button1.Enabled = False
                Button2.Enabled = True
                Button3.Text = "Cancel"
                Button2.Text = "Save"
                DataGridView1.Enabled = False

            End If
            If mintRowWeAreEditing = -1 Then Exit Sub 'haven't clicked Edit button yet

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick

        With DataGridView1
            Try
                Button2.Enabled = True
                TextBox7.Text = .Item(0, .CurrentRow.Index).Value.ToString
                TextBox1.Text = .Item(1, .CurrentRow.Index).Value.ToString
                ComboBox2.Text = .Item(2, .CurrentRow.Index).Value.ToString
                ComboBox3.Text = .Item(3, .CurrentRow.Index).Value.ToString
                TextBox8.Text = .Item(4, .CurrentRow.Index).Value.ToString
                TextBox9.Text = .Item(5, .CurrentRow.Index).Value.ToString
                MaskedTextBox1.Text = .Item(6, .CurrentRow.Index).Value.ToString
                TextBox5.Text = .Item(7, .CurrentRow.Index).Value.ToString
                gender = .Item(8, .CurrentRow.Index).Value.ToString
                TextBox4.Text = .Item(9, .CurrentRow.Index).Value.ToString
                ComboBox1.Text = .Item(10, .CurrentRow.Index).Value.ToString

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "Cancel" Then
            reload()
            Return
        End If
        If Button3.Text = "Close" Then
            Me.Close()
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Text = "Staff" Then
            TextBox8.Text = "4150000"
        ElseIf ComboBox3.Text = "Manager" Then
            TextBox8.Text = "5000000"
        ElseIf ComboBox3.Text = "Department Head" Then
            TextBox8.Text = "9000000"
        Else
            TextBox8.Text = "0"
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Try
            TextBox5.Text = Val(TextBox8.Text) - Val(TextBox9.Text)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
