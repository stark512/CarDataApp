﻿using Car_Data_Application.Models;
using Car_Data_Application.Models.Vehicle_Classes;
using Car_Data_Application.Models.XML_Models;
using Car_Data_Application.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Car_Data_Application.Controllers
{
    class CostContentGenerator : CarDataAppController
    {
        public void CostGenerator(MainWindow mw, User user, CostPage translation)
        {
            InitialAssignValue(mw, user);

            Grid MainGrid = new Grid();

            int index = 0;
            foreach (Service servis in user.Vehicles[user.ActiveCarIndex].Services)
            {
                MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(150) });

                Grid CostInfoGrid = new Grid();
                SetGridProps(ref CostInfoGrid, index);

                CostInfoGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(114) });
                CostInfoGrid.ColumnDefinitions.Add(new ColumnDefinition());

                CostInfoGrid.Children.Add(GenerateIcon("../../../Images/Icons/dollar.png", 0, 0));

                Grid CostInfoGridContent = new Grid();
                CostInfoGridContent.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetColumn(CostInfoGridContent, 1);

                for (int x = 0; x < 5; x++)
                {
                    RowDefinition CostInfoRow = new RowDefinition();
                    CostInfoGridContent.RowDefinitions.Add(CostInfoRow);
                }
                for (int y = 0; y < 2; y++)
                {
                    ColumnDefinition CostInfoColumn = new ColumnDefinition();
                    CostInfoGridContent.ColumnDefinitions.Add(CostInfoColumn);
                }

                string LightTextColor = "#FF9C9397";
                string DarkTextColor = "#FF2A2729"; // change to set in config

                CostInfoGridContent.Children.Add(GenerateTextBlock(translation.Type, PUser.UserLanguage, 1, 0, LightTextColor, HorizontalAlignment.Right));
                CostInfoGridContent.Children.Add(GenerateTextBlock(translation.Date, PUser.UserLanguage, 2, 0, LightTextColor, HorizontalAlignment.Right));
                CostInfoGridContent.Children.Add(GenerateTextBlock(translation.Cost, PUser.UserLanguage, 3, 0, LightTextColor, HorizontalAlignment.Right));
                CostInfoGridContent.Children.Add(GenerateTextBlock(translation.Comment, PUser.UserLanguage, 4, 0, LightTextColor, HorizontalAlignment.Right));

                CostInfoGridContent.Children.Add(GenerateTextBlock(null, servis.Name.ToString(), 0, 0, DarkTextColor, HorizontalAlignment.Center, VerticalAlignment.Center, true));
                CostInfoGridContent.Children.Add(GenerateTextBlock(null, servis.Category.ToString(), 1, 1));
                CostInfoGridContent.Children.Add(GenerateTextBlock(null, servis.Date.ToString(), 2, 1));
                CostInfoGridContent.Children.Add(GenerateTextBlock(null, servis.Price.ToString() + " zł", 3, 1));
                CostInfoGridContent.Children.Add(GenerateTextBlock(null, servis.Comment.ToString(), 4, 1));

                CostInfoGrid.Children.Add(CostInfoGridContent);

                MainGrid.Children.Add(CostInfoGrid);
                index++;
            }        
            mw.ScrollViewerContent.Content = MainGrid;
        }

        private void InitialAssignValue(MainWindow mw, User user)
        {
            mw.WhereAreYou = "CostsPage";
            mainWindow = mw;
            PUser = user;
            SetButtonColor(mainWindow.WhereAreYou, ((Grid)mainWindow.FindName("SidePanel")));
        }
    }
}
