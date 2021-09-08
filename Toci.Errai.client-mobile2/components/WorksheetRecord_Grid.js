import React, { useState } from 'react'
import { DataTable } from 'react-native-paper'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import { Button, Text, View, Pressable } from 'react-native'
import { environment } from '../environment'

export default function WorksheetRecord_Grid(props) {

    const deleteData = (index) => {

        let x = props.gridData[index]

        let id_ = x['id']
        props.setloading(true)
        fetch(environment.prodApiUrl + "api/AreaQuantity/DeleteById?Id=" + id_, {
            method: "DELETE",
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify([x])
        }).then( response => {
            console.log(response)
            props.updateTableAfterRequest()
        }).catch(error => {
            console.log(error)
        })

    }

    const updateData = (index) => {
        let foundRow = props.gridData[index]

        let _area = props.areas.filter(item => item.code == foundRow['areacode'])[0]

        props.settempAreaquantityRow(prev => {
            return {...prev,
                id: foundRow['id'],
                length: foundRow['length'],
                width: foundRow['width'],
                quantity: foundRow['quantity'],
                idarea: _area.id,
                createdat: foundRow['createdat'],
            }
        })

        props.setbtnvalueHook("UPDATE")
    }

    const displayQuantities = () => {
        if(props.gridData.length < 1) return

        let respo = []

        for(let i = 0; i < props.gridData.length; i++) {
            respo.push(

                <DataTable.Row key={i} style={ worksheetRecord.rowContainer }>
                    <DataTable.Cell key={i + "areacode"} style={worksheetRecord.gridShort}>
                        <Text>
                            {props.gridData[i].areacode}
                        </Text>
                    </DataTable.Cell>

                    <DataTable.Cell key={i + "areaname"} style={worksheetRecord.grid}>
                        <Text>
                            {props.gridData[i].areaname}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "createdat"} style={worksheetRecord.grid}>
                        <Text>
                            { props.gridData[i].createdat?.substr(0, 10) }
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "length"} style={worksheetRecord.grid}>
                        <Text>
                            {props.gridData[i].length}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "width"} style={worksheetRecord.grid}>
                        <Text>
                            {props.gridData[i].width}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "quantity"} style={worksheetRecord.gridShort}>
                        <Text>
                            {props.gridData[i].quantity}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "initials"} style={worksheetRecord.gridShort}>
                        <Text>
                            {props.gridData[i].initials}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "updDateF"} style={worksheetRecord.gridShort}>
                        <Text onPress={() => updateData(i)}>UPDATE</Text>
                        {/* <Text>
                            <Pressable style={worksheetRecord.button}>
                                <Text style={worksheetRecord.text}>UPDATE</Text>
                            </Pressable>
                        </Text> */}
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "delete"} style={worksheetRecord.gridShort}>
                        <Text>
                            <Pressable style={worksheetRecord.button} onPress={() => deleteData(i)}>
                                <Text style={worksheetRecord.text}>X</Text>
                            </Pressable>
                        </Text>
                    </DataTable.Cell>
                </DataTable.Row>


            )
        }

        return respo;

    }


    return (
        <View>
            <DataTable style={globalStyles.tableContainer}>
                { displayQuantities() }
            </DataTable>
        </View>
    )
}
