import React, { useState, useEffect } from "react";
// import { openDatabase } from 'react-native-sqlite-storage';
import * as SQLite from "expo-sqlite";
const db = SQLite.openDatabase("db.testDb");

      export function CreateTable() {
        console.log(2);
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


            } else {
              tx.executeSql('select * from sqlite_master', [], (_, { rows }) =>
                console.log('the number of rows are',JSON.stringify(rows))
              );
            }
          }
        );
      });
      }


      export function testColumn() {
        console.log(2);

        db.transaction(tx => {
          tx.executeSql("drop table if EXISTS content_cache", [], (response) => {
            console.log(response);
          });
         });

        db.transaction(tx => {
          tx.executeSql(
           `create table content_cache (
             id integer primary key not null,
             Idworksheet int,
             columnIndex int,
             rowIndex int,
             value text,
             createdAt time(YYYY-MM-DD HH:MM:SS),
             updatedAt time(YYYY-MM-DD HH:MM:SS)
             );`, [], (res) => {console.log(res);}, error => {
               console.log(error);
             }
          );
         });

        /* db.transaction(tx => {
          tx.executeSql(
            "INSERT INTO content_cache (id, Idworksheet, columnIndex, rowIndex, value, createdAt, updatedAt) VALUES (?,?,?,?,?,?,?)",
            [1, 5, 1, 1, "OK", "2021-07-27 15:50:50", "2021-07-27 15:50:50"],
            //[id, Idworksheet, columnIndex, rowIndex, value, createdAt, updatedAt],
            (tx2, results) => {
              console.log(results);
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
         });*/

        db.transaction(tx => {
          tx.executeSql('select * from content_cache', [], (_, { rows }) =>
            console.log(rows)
          );
        });







        /*
        db.transaction(function (txn) {
        txn.executeSql(
          "SELECT * FROM content_cache'",
          [],
          function (tx, res) {
            console.log(tx);
            console.log(res);
            return
            console.log("item:", res.rows.length);
            if (res.rows.length == 0) {
              txn.executeSql("DROP TABLE IF EXISTS table_item", []);
              txn.executeSql(
                "CREATE TABLE IF NOT EXISTS table_item(item_id INTEGER PRIMARY KEY AUTOINCREMENT, item_1 VARCHAR(20), item_2 INT(10), item_3 VARCHAR(255))",
                []
              );


            } else {

            }
          }
        );
      });*/
      }




      export function addOrUpdateItem([...object]) {
        db.transaction("xx", [], )


        //SELECT name FROM sqlite_master WHERE type='table' AND name='table_item'
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
