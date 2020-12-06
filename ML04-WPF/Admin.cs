using System;
using System.Collections.Generic;
using System.Text;

namespace ML03
{
    // devin testing the git.
   ///
   /// \brief <i>Class</i> <b>Admin</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the Admin.
   /// 
   /// As an Admin I want to be able to have access to options to allow them to update, maintain and modify
   /// the database as required in order to maintain the data log controller and the system database.
   /// 
   /// Child derived from Parent UserRole class.
   ///
   class Admin : UserRole
   {
      string logFiles
      { get; set; }
      int ipAddress
      { get; set; }
      int portAddress
      { get; set; }
      int rate
      { get; set; }
      int fee
      { get; set; }
      string carrierData
      { get; set; }

      ///
      /// \brief Constructor for <b>Admin</b>
      /// \details <b>Details</b>
      ///
      /// Creates the required object. 
      ///
      public Admin() : base()
      {
            
      }


      ///
      /// \brief <b>addCarrierData</b> function for <b>Admin</b>
      /// \details <b>Details</b>
      ///
      /// Add Carrier Data to the database. 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void addCarrierData()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>updateCarrierData</b> function for <b>Admin</b>
      /// \details <b>Details</b>
      ///
      /// Update Carrier Data in database. 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void updateCarrierData()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>deleteCarrierData</b> function for <b>Admin</b>
      /// \details <b>Details</b>
      ///
      /// Delete Carrier Data in database. 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void deleteCarrierData()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>routeTable</b> function for <b>Admin</b>
      /// \details <b>Details</b>
      ///
      /// Route table distances in database. 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void routeTable()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>backupData</b> function for <b>Admin</b>
      /// \details <b>Details</b>
      ///
      /// Backu routine initiated for database
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void backupData()
      {
         // TODO_implement
      }
   }
}
