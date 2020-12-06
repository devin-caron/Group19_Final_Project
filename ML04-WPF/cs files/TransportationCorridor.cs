using System;
using System.Collections.Generic;
using System.Text;

namespace ML03
{
   ///
   /// \brief <i>Class</i> <b>TransportationCorridor</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the TransportationCorridor.
   /// 
   /// As a TransportationCorridor I want to be able to tally the extra charges OSHT adds on to
   /// the final cost for the Buyer to cover overages.
   /// 
   /// Child derived from Parent MySql class.
   ///
   class TransportationCorridor : MySql
   {

      string destination
      { get; set; }
      int distanceKms
      { get; set; }
      float distanceTime
      { get; set; }
      string provinceWest
      { get; set; }
      string provinceEast
      { get; set; }


      ///
      /// \brief Constructor for <b>TransportationCorridor</b>
      /// \details <b>Details</b>
      /// 
      /// Creates the required object. 
      ///
      public TransportationCorridor() : base()
      {

      }

      ///
      /// \brief <b>routePlanning</b> function for <b>TransportationCorridor</b>
      /// \details <b>Details</b>
      ///
      /// Supplies the truck routes available for planning trip Order.
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  bool  - <b>true</b>
      ///
      public void routePlanning()
      {
         // TODO_implement
      }
   }
}
