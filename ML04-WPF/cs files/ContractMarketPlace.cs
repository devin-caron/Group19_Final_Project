using System;
using System.Collections.Generic;
using System.Text;

namespace ML03
{
   ///
   /// \brief <i>Class</i> <b>ContractMarketPlace</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the ContractMarketPlace.
   /// 
   /// As a ContractMarketPlace link I want to be able to access external information,
   /// derived from the Carrier Update System and Contract Market Place in order to
   /// represent the options, through to the Communications link.
   /// 
   /// Child derived from Parent Communications class.
   ///
   class ContractMarketPlace : Communications
   {

      string clientName
      { get; set; }
      bool jobType
      { get; set; }
      int quantity
      { get; set; }
      string origin
      { get; set; }
      string destination
      { get; set; }
      bool vanType
      { get; set; }


      ///
      /// \brief Constructor for <b>ContractMarketPlace</b>
      /// \details <b>Details</b>
      /// 
      /// Creates the required object. 
      ///
      public ContractMarketPlace() : base()
      {

      }

      ///
      /// \brief <b>pullshippingRequest</b> function for <b>ContractMarketPlace</b>
      /// \details <b>Details</b>
      ///
      /// Link and Pull of remote shipping database for options available
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void pullshippingRequest()
      {
         // TODO_implement
      }
   }
}
