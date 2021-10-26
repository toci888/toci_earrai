import React, { useState } from 'react'
import { DataTable } from 'react-native-paper'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import { Button, Text, View, Pressable } from 'react-native'
import { environment } from '../environment'

export default function WorksheetRecord_Grid(props) {

    const deleteData = (index) => {

        let x = props.AreaQuantities[index]

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
        let foundRow = props.AreaQuantities[index]

        let _area = props.areas.filter(item => item.code == foundRow['areacode'])[0]

        props.setAreaQuantities(prev => {
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

    const nowUpdating = (i) => {
        return props.setAreaQuantities['id'] == props.AreaQuantities[i]['id']
    }

    const displayQuantities = () => {
        if(props.AreaQuantities.length < 1) return

        let respo = []

        for(let i = 0; i < props.AreaQuantities.length; i++) {
            respo.push(
            <>
                <DataTable.Row key={i} style={[ worksheetRecord.rowContainerTop    ]}>
                    <DataTable.Cell key={i + "createdat"} style={[worksheetRecord.grid, {backgroundColor: nowUpdating(i) ? "red" : "" }]}>
                        <Text style={{backgroundColor: nowUpdating(i) ? "red" : "" }}>
                            { props.AreaQuantities[i].createdat?.substr(0, 10) }
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "length"} style={worksheetRecord.grid}>
                        <Text>
                            L: {props.AreaQuantities[i].length}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "width"} style={worksheetRecord.grid}>
                        <Text>
                            W: {props.AreaQuantities[i].width}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "quantity"} style={worksheetRecord.gridShort}>
                        <Text>
                            Q: {props.AreaQuantities[i].quantity}
                        </Text>
                    </DataTable.Cell>
                </DataTable.Row>
                <DataTable.Row key={i + "2nd"} style={ worksheetRecord.rowContainerBottom }>
                    <DataTable.Cell key={i + "initials"} style={worksheetRecord.gridShort}>
                        <Text>
                            Initials: {props.AreaQuantities[i].initials}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "areacode"} style={worksheetRecord.gridShort}>
                        <Text>
                            {props.AreaQuantities[i].areacode}: {props.AreaQuantities[i].areaname}
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
            </>

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
