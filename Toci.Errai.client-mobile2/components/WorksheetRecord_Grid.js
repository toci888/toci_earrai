import React, { useState } from 'react'
import { DataTable } from 'react-native-paper'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import { Button, Text, View, Pressable } from 'react-native'
import { environment } from '../environment'
import { deleteRequestParams, deleteUrl } from './RequestConfig'



export default function WorksheetRecord_Grid(props) {

    const deleteData = (index_) => {

        let x = props.areaQuantities[index_]
        console.log(x)

        props.setloading(true)
        fetch(deleteUrl(x['id']), deleteRequestParams(x['id'])).then( response => {
            console.log(response)
            props.deleteProduct(index_)
        }).catch(error => {
            console.log(error)
        }).finally(data => {
            props.setloading(false)
        })
    }

    const updateData = (index_) => {
        props.setUpdatingIndex(index_)
        let foundRow = props.areaQuantities[index_]

        let _area = props.areas.filter(item => item.code == foundRow['areacode'])[0]

        props.settempAreaquantityRow(prev => foundRow)

        props.settempAreaquantityRow(prev => {
            return {...prev,
                id: foundRow['id'],
                length: foundRow['length'],
                width: foundRow['width'],
                quantity: foundRow['quantity'],
                idarea: _area['id'],
                createdat: foundRow['createdat'],
            }
        })

        props.setbtnvalueHook("UPDATE")
    }

    const nowUpdating = (i) => {
        return false //props.setAreaQuantities['id'] == props.AreaQuantities[i]['id']
    }

    const displayQuantities = () => {
        if(!props.areaQuantities) return

        let respo = []

        for(let i = 0; i < props.areaQuantities.length; i++) {
            respo.push(
            <View key={i+"he"}>
                <DataTable.Row key={i} style={[ worksheetRecord.rowContainerTop    ]}>
                    <DataTable.Cell key={i + "createdat"} style={[worksheetRecord.grid, {backgroundColor: nowUpdating(i) ? "red" : "" }]}>
                        <Text style={{backgroundColor: nowUpdating(i) ? "red" : "" }}>
                            { props.areaQuantities[i].createdat?.substr(0, 10) }
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "length"} style={worksheetRecord.grid}>
                        <Text>
                            L: {props.areaQuantities[i]?.length}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "width"} style={worksheetRecord.grid}>
                        <Text>
                            W: {props.areaQuantities[i]?.width}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "quantity"} style={worksheetRecord.gridShort}>
                        <Text>
                            Q: {props.areaQuantities[i].quantity}
                        </Text>
                    </DataTable.Cell>
                </DataTable.Row>
                <DataTable.Row key={i + "2nd"} style={ worksheetRecord.rowContainerBottom }>
                    <DataTable.Cell key={i + "initials"} style={worksheetRecord.gridShort}>
                        <Text>
                            Initials: {props.areaQuantities[i].initials}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "areacode"} style={worksheetRecord.gridShort}>
                        <Text>
                            {props.areaQuantities[i].areacode}: {props.areaQuantities[i].areaname}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "updDateF"} style={worksheetRecord.gridShort}>
                        <Text>
                            <Pressable style={worksheetRecord.buttonUpdate} onPress={() => updateData(i)}>
                                <Text style={worksheetRecord.text}>UPDATE</Text>
                            </Pressable>
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "delete"} style={worksheetRecord.gridShort}>
                        <Text>
                            <Pressable style={worksheetRecord.button} onPress={() => deleteData(i)}>
                                <Text style={worksheetRecord.text}>DELETE</Text>
                            </Pressable>
                        </Text>
                    </DataTable.Cell>
                </DataTable.Row>

            </View>

            )
        }

        return respo;

    }


    return (
        <View style={{margin: 10}}>
            <DataTable style={globalStyles.tableContainer}>
                { displayQuantities() }
            </DataTable>
        </View>
    )
}
