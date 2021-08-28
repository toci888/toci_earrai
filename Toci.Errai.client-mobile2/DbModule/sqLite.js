import React, { useState, useEffect } from "react";
// import { openDatabase } from 'react-native-sqlite-storage';
import * as SQLite from "expo-sqlite";
const db = SQLite.openDatabase("db.testDb");

      export function CreateTable() {
        db.transaction(function (txn) {
        txn.executeSql(
          "SELECT name FROM sqlite_master WHERE type='table' AND name='table_item'",
          [],
          function (tx, res) {
            console.log("item:", res.rows.length);
            if (res.rows.length == 0) {
              txn.executeSql("DROP TABLE IF EXISTS table_item", []);
              txn.executeSql(
                "CREATE TABLE IF NOT EXISTS table_item(item_id INTEGER PRIMARY KEY AUTOINCREMENT, item_1 VARCHAR(20), item_2 INT(10), item_3 VARCHAR(255))",
                []
              );
            }
          }
        );
      });
      }


    export function CreateItem(item_1, item_2, item_3) {
      db.transaction(function (tx) {
        tx.executeSql(
          "INSERT INTO table_item (item_1, item_2, item_3) VALUES (?,?,?)",
          [item_1, item_2, item_3],
          (tx, results) => {
            console.log("Results", results.rowsAffected);
            if (results.rowsAffected > 0) {
              Alert.alert(
                "Success",
                "ok",
                [
                  {
                    text: "Ok",
                   
                  },
                ],
                { cancelable: false }
              );
            } else alert("Failed");
          }
        );
      });
    }

     export function UpdateItem(item_1, item_2, item_3, item_Id) {
       db.transaction((tx) => {
         tx.executeSql(
           "UPDATE table_item set item_1=?, item_2=?, item_3=? where item_id=?",
           [item_1, item_2, item_3, item_Id],
           (tx, results) => {
             console.log("Results", results.rowsAffected);
             if (results.rowsAffected > 0) {
               Alert.alert(
                 "Success",
                 "updated successfully",
                 [
                   {
                     text: "Ok",
                   },
                 ],
                 { cancelable: false }
               );
             } else alert("Update Failed");
           }
         );
       });
     };

     export function DeleteItem(item_Id) {
       db.transaction((tx) => {
         tx.executeSql(
           "DELETE FROM  table_item where item_id=?",
           [item_Id],
           (tx, results) => {
             console.log("Results", results.rowsAffected);
             if (results.rowsAffected > 0) {
               Alert.alert(
                 "Success",
                 "Delete",
                 [
                   {
                     text: "Ok",
                   },
                 ],
                 { cancelable: false }
               );
             } else {
               alert("item Id");
             }
           }
         );
       });
     }

      // export function ViewItem() {
    //     db.transaction((tx) => {
    //       tx.executeSql("SELECT * FROM table_item", [], (tx, results) => {
    //         var temp = [];
    //         for (let i = 0; i < results.rows.length; ++i)
    //           temp.push(results.rows.item(i));
    //         //setFlatListItems(temp);
    //       });
    //     });
    // }
