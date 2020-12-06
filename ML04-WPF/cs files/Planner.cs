using System;
using System.Collections.Generic;
using System.Text;

namespace ML03
{
   ///
   /// \brief <i>Class</i> <b>Planner</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the Planner.
   /// 
   /// As a Planner I want to be able to access all the internal and external
   /// requirement metadata for it to be feasible to enter in order(s) in order
   /// to get the most time sensitive and cost-effective results for the buyer’s request.
   /// 
   /// Child derived from Parent UserRole class.
   ///
   class Planner : UserRole
   {

      int buyerOrderID
      { get; set; }
      float timeProgression
      { get; set; }
      bool orderComplete
      { get; set; }


      ///
      /// \brief Constructor for <b>Planner</b>
      /// \details <b>Details</b>
      /// 
      /// Creates the required object. 
      ///
      public Planner() : base()
      {

      }


      ///
      /// \brief <b>contractReview</b> function for <b>Planner</b>
      /// \details <b>Details</b>
      ///
      /// Contract Review initiator
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
      /// \brief <b>newOrder</b> function for <b>Planner</b>
      /// \details <b>Details</b>
      ///
      /// New Order initiator
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
      /// \brief <b>selectCities</b> function for <b>Planner</b>
      /// \details <b>Details</b>
      ///
      /// Select Cities options
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
      /// \brief <b>reviewOrders</b> function for <b>Planner</b>
      /// \details <b>Details</b>
      ///
      /// City comparison for characteristics
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
      /// \brief <b>InvoiceGeneration</b> function for <b>Planner</b>
      /// \details <b>Details</b>
      ///
      /// Generates the approved final Invoice
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
