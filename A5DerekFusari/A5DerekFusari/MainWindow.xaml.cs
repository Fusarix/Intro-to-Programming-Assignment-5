/* 
Programmer: Derek Fusari
Assignemnt 5
Purpose: To demonstrate basic knowledge of GUI and arrays
Date: December 3, 2015
*/

using System;
using System.Windows;
using System.Windows.Controls;

namespace A5DerekFusari
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Creates three arrays and a boolean to keep track
        //of all data
        bool[] reservedArray = new bool[16];
        Button[] btnArray = new Button[16];
        TextBox[] txtArray = new TextBox[16];
        bool remove = false;
               
        public MainWindow()
        {
            InitializeComponent();
            //Assigns each button and text
            //box to the correct element in the array
            btnArray[0] = btnA1;
            btnArray[1] = btnA2;
            btnArray[2] = btnA3;
            btnArray[3] = btnA4;

            btnArray[4] = btnB1;
            btnArray[5] = btnB2;
            btnArray[6] = btnB3;
            btnArray[7] = btnB4;

            btnArray[8] = btnC1;
            btnArray[9] = btnC2;
            btnArray[10] = btnC3;
            btnArray[11] = btnC4;

            btnArray[12] = btnD1;
            btnArray[13] = btnD2;
            btnArray[14] = btnD3;
            btnArray[15] = btnD4;

            txtArray[0] = txtA1;
            txtArray[1] = txtA2;
            txtArray[2] = txtA3;
            txtArray[3] = txtA4;

            txtArray[4] = txtB1;
            txtArray[5] = txtB2;
            txtArray[6] = txtB3;
            txtArray[7] = txtB4;

            txtArray[8] = txtC1;
            txtArray[9] = txtC2;
            txtArray[10] = txtC3;
            txtArray[11] = txtC4;

            txtArray[12] = txtD1;
            txtArray[13] = txtD2;
            txtArray[14] = txtD3;
            txtArray[15] = txtD4;
        }
        private void BtnMakeReservation(object sender, RoutedEventArgs e)
        {
            int indexReservedCheck = 0;
            bool seatsFull = false;
            
            //sets a loop to check if all the seats have been reserved
            while(indexReservedCheck < 16)
            {
                if (reservedArray[indexReservedCheck] == true)
                {
                    indexReservedCheck++;
                    if (indexReservedCheck == 16)
                    {
                        seatsFull = true;
                    }
                }
                else
                {
                    indexReservedCheck += 20;
                }
            }
            //If the seats are not full
            if (seatsFull == false)
            {
                //enable all buttons                                           
                remove = false;
                int index = 0;
                btnMakeReservation.IsEnabled = false;
                btnRemoveReservation.IsEnabled = false;

                while (index < 16)
                {
                    if (reservedArray[index] == false)
                    {
                        btnArray[index].IsEnabled = true;
                    }
                    index++;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("There are no available seats. " 
                    + "A reservation must be removed first.");
            }
        }
        private void BtnRemoveReservation(object sender, RoutedEventArgs e)
        {
            int indexReservedCheck = 0;
            bool noReservations = false;

            btnName.IsEnabled = true;
            btnSeat.IsEnabled = true;
            txtRemoveName.IsEnabled = true;
            txtRemoveSeat.IsEnabled = true;

            //checks if there are any reservations
            while (indexReservedCheck < 16)
            {
                if (reservedArray[indexReservedCheck] == false)
                {
                    indexReservedCheck++;
                    if (indexReservedCheck == 16)
                    {
                        noReservations = true;
                    }
                }
                else
                {
                    indexReservedCheck += 20;
                }
            }
            //if there are no reservations,
            //enable the buttons and allow the user to remove a reservation
            if (noReservations == false)
            {
                remove = true;
                int index = 0;

                btnMakeReservation.IsEnabled = false;
                btnRemoveReservation.IsEnabled = false;

                while (index < 16)
                {
                    if (reservedArray[index] == true)
                    {
                        btnArray[index].IsEnabled = true;
                    }
                    index++;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("There are no reserved seats to remove.");
                btnName.IsEnabled = false;
                btnSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveSeat.IsEnabled = false;
            }
        }

        private void BtnAdd_Remove(object sender, RoutedEventArgs e)
        {
            int indexTxt = 0;
            int indexBtn = 0;
            int indexCheck = 0;
            bool check = false;
            //sets a loop to check if a text box is enabled
                while (indexCheck < 16)
                {
                    if (txtArray[indexCheck].IsEnabled == true)
                    {
                    //if the text box is enabled, and the text is blank or unchanged
                        if ((txtArray[indexCheck].Text == "") || (txtArray[indexCheck].Text == "Enter"
                               +" Your Name:"))
                        {
                        //Propt the user, and reset the forum
                            System.Windows.Forms.MessageBox.Show("You did not enter your name, " 
                                + "please reselct your reservation.");
                            btnMakeReservation.IsEnabled = false;
                            btnRemoveReservation.IsEnabled = false;
                            txtArray[indexCheck].Text = "Enter Your Name:";
                            reservedArray[indexCheck] = false;
                            check = true;
                        }
                    }
                    indexCheck++;
                }

                //disables all buttons and text boxes, and properly resets the form
                while (indexTxt < 16)
                {

                    txtArray[indexTxt].IsEnabled = false;
                    indexTxt++;
                }

                while (indexBtn < 16)
                {
                    btnArray[indexBtn].IsEnabled = false;
                    indexBtn++;
                }

                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
            //If the input was invalid, reset the form
                if (check == true)
                {
                    int indexBtnCheck = 0;
                    while (indexBtnCheck < 16)
                    {
                        btnArray[indexBtnCheck].IsEnabled = true;
                        indexBtnCheck++;
                    }

                    btnMakeReservation.IsEnabled = false;
                    btnRemoveReservation.IsEnabled = false;
                }

                btnAdd_Remove.IsEnabled = false;
            //If the input was valid, add the reservation and reset the form
                if (check == false)
                {
                    btnRemoveReservation.IsEnabled = true;
                    btnMakeReservation.IsEnabled = true;
                    System.Windows.Forms.MessageBox.Show("Your reservation "
                        +"has been added.");
                }               
        }

        private void BtnA1(object sender, RoutedEventArgs e)
        {
            //check if they are removing or adding a reservation
            if (remove == false)
            {
                reservedArray[0] = true;
                
                int index = 0;
                //reset the forum
                while (index < 16)
                {                 
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;                
                    index++;
                }            
                //enable the text box for user input
                txtA1.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;
            }
            else //if you are removing a reservation, reset the info
            {
                txtArray[0].Text = "Enter Your Name:";
                reservedArray[0] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnA2(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[1] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }

                txtA2.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;

            }
            else
            {
                txtArray[1].Text = "Enter Your Name:";
                reservedArray[1] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnA3(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[2] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }
                txtA3.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;

            }
            else
            {
                txtArray[2].Text = "Enter Your Name:";
                reservedArray[2] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnA4(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[3] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }
                txtA4.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;
            }
            else
            {
                txtArray[3].Text = "Enter Your Name:";
                reservedArray[3] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnB1(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[4] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }
                txtB1.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;

            }
            else
            {
                txtArray[4].Text = "Enter Your Name:";
                reservedArray[4] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnB2(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[5] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }

                txtB2.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;

            }
            else
            {
                txtArray[5].Text = "Enter Your Name:";
                reservedArray[5] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnB3(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[6] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }

                txtB3.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;

            }
            else
            {
                txtArray[6].Text = "Enter Your Name:";
                reservedArray[6] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnB4(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[7] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }

                txtB4.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;

            }
            else
            {
                txtArray[7].Text = "Enter Your Name:";
                reservedArray[7] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnC1(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[8] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }
                txtC1.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;

            }
            else
            {
                txtArray[8].Text = "Enter Your Name:";
                reservedArray[8] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnC2(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[9] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }
                txtC2.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;

            }
            else
            {
                txtArray[9].Text = "Enter Your Name:";
                reservedArray[9] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnC3(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[10] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }
                txtC3.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;
            }
            else
            {
                txtArray[10].Text = "Enter Your Name:";
                reservedArray[10] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnC4(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[11] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }
                txtC4.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;
            }
            else
            {
                txtArray[11].Text = "Enter Your Name:";
                reservedArray[11] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnD1(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[12] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }
                txtD1.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;
            }
            else
            {
                txtArray[12].Text = "Enter Your Name:";
                reservedArray[12] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnD2(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[13] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }
                txtD2.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;
            }
            else
            {
                txtArray[13].Text = "Enter Your Name:";
                reservedArray[13] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnD3(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[14] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }
                txtD3.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;

            }
            else
            {
                txtArray[14].Text = "Enter Your Name:";
                reservedArray[14] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnD4(object sender, RoutedEventArgs e)
        {
            if (remove == false)
            {
                reservedArray[15] = true;

                int index = 0;

                while (index < 16)
                {
                    btnArray[index].IsEnabled = false;
                    txtArray[index].IsEnabled = false;
                    index++;
                }
                txtD4.IsEnabled = true;
                btnAdd_Remove.IsEnabled = true;

            }
            else
            {
                txtArray[15].Text = "Enter Your Name:";
                reservedArray[15] = false;
                DisableButtons();
                System.Windows.Forms.MessageBox.Show("Your reservation was removed.");
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                txtRemoveSeat.IsEnabled = false;
                txtRemoveName.IsEnabled = false;
                txtRemoveName.Text = "";
                txtRemoveSeat.Text = "";
            }
        }

        private void BtnExit(object sender, RoutedEventArgs e)
        {
            //exit the forum
            Environment.Exit(0);
        }

        private void DisableButtons()
        {
            //Disable all the buttons
            int index = 0;

            while (index < 16)
            {
                btnArray[index].IsEnabled = false;
                index++;
            }

            btnName.IsEnabled = false;
            btnSeat.IsEnabled = false;
        }
        private void DisableTextBoxes()
        {
            //disable all the text boxes
            int index = 0;
            while (index < 16)
            {
                txtArray[index].IsEnabled = false;
                if(reservedArray[index] == false)
                {
                    txtArray[index].Text = "Enter Your Name:";
                    
                }
                index++;
            }
            txtRemoveName.IsEnabled = false;
            txtRemoveSeat.IsEnabled = false;
        }

        private void BtnBack(object sender, RoutedEventArgs e)
        {
            //Reset the forum and remove currently entered data to prevent errors
            btnMakeReservation.IsEnabled = true;
            btnRemoveReservation.IsEnabled = true;
            btnAdd_Remove.IsEnabled = false;
            int indexCheck = 0;
            while (indexCheck < 16)
            {
                if (txtArray[indexCheck].IsEnabled == true)
                {
                        txtArray[indexCheck].Text = "Enter Your Name:";
                        reservedArray[indexCheck] = false;                                    
                }
                indexCheck++;
            }
            DisableButtons();
            DisableTextBoxes();
            txtRemoveSeat.Text = "";
            txtRemoveName.Text = "";           
        }

        private void BtnName(object sender, RoutedEventArgs e)
        {
            string nameEntered = "";
            int i = 0;
            bool noReservation = false;

            nameEntered = txtRemoveName.Text;

            while (i < 16)
            {
                //if the name entered matches a reservation, 
                //remove it and reset the form
                if(txtArray[i].Text.ToUpper() == nameEntered.ToUpper() 
                    && reservedArray[i] == true)
                {
                    txtArray[i].Text = "Enter Your Name:";
                    reservedArray[i] = false;
                    System.Windows.Forms.MessageBox.Show("Your Reservation was removed");
                    txtRemoveName.Text = "";
                    i += 20;
                }
                else if(i == 15)
                {
                    System.Windows.Forms.MessageBox.Show("There was no reservation of "
                        +"that name");
                    noReservation = true;
                    i += 20;
                    
                }
                else
                {
                    i++;
                }
            }
            //IF there was a reservation found
            if (noReservation == false)
            {
                DisableButtons();
                DisableTextBoxes();
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                btnAdd_Remove.IsEnabled = false;
            }
            //otherwise
            else
            {
                txtRemoveName.Text = "";
            }
        }

        private void BtnSeat(object sender, RoutedEventArgs e)
        {
            string seatEntered = "";
            int i = 0;
            bool noReservation = false;
            string[] btnName = new string[16];
            btnName[0] = "A1";
            btnName[1] = "A2";
            btnName[2] = "A3";
            btnName[3] = "A4";

            btnName[4] = "B1";
            btnName[5] = "B2";
            btnName[6] = "B3";
            btnName[7] = "B4";

            btnName[8] = "C1";
            btnName[9] = "C2";
            btnName[10] = "C3";
            btnName[11] = "C4";

            btnName[12] = "D1";
            btnName[13] = "D2";
            btnName[14] = "D3";
            btnName[15] = "D4";

            seatEntered = txtRemoveSeat.Text;

            while(i < 16)
            {
                if(btnName[i].ToUpper() == seatEntered.ToUpper()
                    && (reservedArray[i] == true))
                {
                    txtArray[i].Text = "Enter Your Name:";
                    reservedArray[i] = false;
                    System.Windows.Forms.MessageBox.Show("Your Reservation was removed");
                    txtRemoveSeat.Text = "";
                    i += 20;
                }
                else if(i == 15)
                {
                    System.Windows.Forms.MessageBox.Show("There was no reservation of "
                       + "that name");
                    noReservation = true;
                    i += 20;
                }
                else
                {
                    i++;
                }
            }
            if (noReservation == false)
            {
                DisableButtons();
                DisableTextBoxes();
                btnMakeReservation.IsEnabled = true;
                btnRemoveReservation.IsEnabled = true;
                btnAdd_Remove.IsEnabled = false;
            }
            else
            {
                txtRemoveSeat.Text = "";
            }
        }        
    }
}
