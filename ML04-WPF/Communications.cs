using System;
using System.Collections.Generic;
using System.Text;

namespace ML03
{
   ///
   /// \brief <i>Class</i> <b>Communications</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the Communications.
   /// 
   /// As a Communications link I want to be able to provide external information,
   /// derived from the Carrier Update System and Contract Market Place in order to
   /// relay the information to the Logic Data Controller to make the most expedient
   /// choices in fulfilling Order requests.
   /// 
   /// Child derived from Parent DataLogicController class.
   ///
   class Communications : DataLogicController
   {

      int carrierUpdateID
      { get; set; }
      int contractMarketID
      { get; set; }
      bool retrieveData
      { get; set; }
      string shippingInfo
      { get; set; }


      ///
      /// \brief Constructor for <b>Communications</b>
      /// \details <b>Details</b>
      /// 
      /// Creates the required object. 
      ///
      public Communications() : base()
      {

      }

      ///
      /// \brief <b>registerSystemLink</b> function for <b>Communications</b>
      /// \details <b>Details</b>
      ///
      /// Socket connection to remote database information
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void registerSystemLink()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>gatherReq</b> function for <b>Communications</b>
      /// \details <b>Details</b>
      ///
      /// Grabs the data required for estimating the transport costs
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void gatherReq()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>shippingDetails</b> function for <b>Communications</b>
      /// \details <b>Details</b>
      ///
      /// City to City transport requirements
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void shippingDetails()
      {
         // TODO_implement
      }
   }
}
