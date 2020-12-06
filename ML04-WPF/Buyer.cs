using System;
using System.Collections.Generic;
using System.Text;

namespace ML03
{
   ///
   /// \brief <i>Class</i> <b>Buyer</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the Buyer.
   ///
   /// As a Buyer I want to be able to access my previous orders in order to check trip options and other
   /// facets of the material for them to make an order(s).
   ///
   /// Child derived from Parent UserRole class.
   ///
   class Buyer : UserRole
   {

      int customerID
      { get; set; }
      int ordercompleteID
      { get; set; }
      int orderID
      { get; set; }
      string city
      { get; set; }

      ///
      /// \brief Constructor for <b>Buyer</b>
      /// \details <b>Details</b>
      ///
      /// Creates the required object. 
      ///
      public Buyer() : base()
      {

      }


      ///
      /// \brief <b>contractReview</b> function for <b>Buyer</b>
      /// \details <b>Details</b>
      ///
      /// Gathers details of contract for Buyer. 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void contractReview()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>newOrder</b> function for <b>Buyer</b>
      /// \details <b>Details</b>
      ///
      /// Starts a new Order form. 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void newOrder()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>selectCities</b> function for <b>Buyer</b>
      /// \details <b>Details</b>
      ///
      /// User City selection. 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void selectCities()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>reviewOrders</b> function for <b>Buyer</b>
      /// \details <b>Details</b>
      ///
      /// Lists the Buyer Orders. 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void reviewOrders()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>InvoiceGeneration</b> function for <b>Buyer</b>
      /// \details <b>Details</b>
      ///
      /// Creates the Buyer Invoice order for Planner to review. 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void InvoiceGeneration()
      {
         // TODO_implement
      }
   }
}
