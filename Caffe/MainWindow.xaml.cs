using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows;
using Caffe.Models;

namespace Caffe;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void btnRead_Click(object sender, RoutedEventArgs e)
    {
        await using var dbContext = new CaffeContext();

        var dtb = new DataTable();

        dtb.Columns.Add(new DataColumn("order_id", typeof(int)));
        dtb.Columns.Add(new DataColumn("name", typeof(string)));
        dtb.Columns.Add(new DataColumn("price", typeof(double)));
        dtb.Columns.Add(new DataColumn("order_description", typeof(string)));

        try
        {
            dbContext.Orders.ToList().ForEach(order =>
            {
                dbContext.Burgers.Where(burger => burger.Id == order.Id).ToList().ForEach(burger =>
                {
                    dtb.Rows.Add(burger.Id, burger.name.ToString(CultureInfo.InvariantCulture), burger.price,
                        order.description);
                });
            });

            Dgv.DataContext = dtb.DefaultView;
        }
        catch (Exception)
        {
            MessageBox.Show(@"Something went wrong", @"INFO");
        }
        finally
        {
            TxtName.Clear();
            TxtPrice.Clear();
            TxtDescription.Clear();
        }
    }

    private async void btnAdd_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            await using var dbContext = new CaffeContext();
            await dbContext.Database.EnsureCreatedAsync();

            if (!string.IsNullOrEmpty(TxtName.Text) || !string.IsNullOrEmpty(TxtPrice.Text) ||
                !string.IsNullOrEmpty(TxtDescription.Text))
            {
                Order order;
                await dbContext.Orders.AddAsync(
                    order = new Order { description = TxtDescription.Text });
                await dbContext.Burgers.AddAsync(
                    new Burger { name = TxtName.Text, price = Convert.ToDouble(TxtPrice.Text), Order = order });
                await dbContext.SaveChangesAsync();

                MessageBox.Show(@"Data is saved", "INFO");
                return;
            }

            MessageBox.Show("Fill the data", "INFO");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "INFO");
        }
        finally
        {
            TxtName.Clear();
            TxtPrice.Clear();
            TxtDescription.Clear();
        }
    }
}