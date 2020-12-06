using System;
using System.Collections.Generic;
using System.Text;

namespace ML03
{
   ///
   /// \brief <i>Class</i> <b>BuyerOrder</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the BuyerOrder.
   /// 
   /// As a BuyerOrder, I want to be able to access the Buyer's needs and requirements
   /// to produce metadata for producing the information for the Planner
   /// 
   /// Parent class.
   ///
   class BuyerOrder
   {

      int buyerOrderID
      { get; set; }
      string targetCities
      { get; set; }
      bool capacityCheck
      { get; set; }
      bool multiTrip
      { get; set; }
      string shippingInfo
      { get; set; }
      float accountBalance
      { get; set; }


      ///
      /// \brief Constructor for <b>BuyerOrder</b>
      /// \details <b>Details</b>
      /// 
      /// Creates the required object. 
      ///
      public BuyerOrder()
      {

      }

      ///
      /// \brief <b>getBuyerOrder</b> function for <b>BuyerOrder</b>
      /// \details <b>Details</b>
      ///
      /// Obtain the Buyer Order form. 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void getBuyerOrder()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>login</b> function for <b>BuyerOrder</b>
      /// \details <b>Details</b>
      ///
      /// Login input. 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void login()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>updateProfile</b> function for <b>BuyerOrder</b>
      /// \details <b>Details</b>
      ///
      /// Update Profile on database. 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void updateProfile()
      {
         // TODO_implement
      }
   }
}
