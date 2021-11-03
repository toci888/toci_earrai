import React, { useState } from 'react'
import { DataTable } from 'react-native-paper'
import { globalStyles } from '../styles/globalStyles'
import { productCSS } from '../styles/Product_Util_Styles'
import { Text, View, Pressable } from 'react-native'
import { deleteRequestParams, deleteUrl } from '../shared/RequestConfig'



export default function Product_AreaQuantities(props) {

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
                <DataTable.Row key={i} style={[ productCSS.rowContainerTop    ]}>
                    <DataTable.Cell key={i + "createdat"} style={[productCSS.grid, {backgroundColor: nowUpdating(i) ? "red" : "" }]}>
                        <Text style={{backgroundColor: nowUpdating(i) ? "red" : "" }}>
                            { props.areaQuantities[i].createdat?.substr(0, 10) }
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "length"} style={productCSS.grid}>
                        <Text>
                            L: {props.areaQuantities[i]?.length}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "width"} style={productCSS.grid}>
                        <Text>
                            W: {props.areaQuantities[i]?.width}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "quantity"} style={productCSS.gridShort}>
                        <Text>
                            Q: {props.areaQuantities[i].quantity}
                        </Text>
                    </DataTable.Cell>
                </DataTable.Row>
                <DataTable.Row key={i + "2nd"} style={ productCSS.rowContainerBottom }>
                    <DataTable.Cell key={i + "initials"} style={productCSS.gridShort}>
                        <Text>
                            Initials: {props.areaQuantities[i].initials}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "areacode"} style={productCSS.gridShort}>
                        <Text>
                            {props.areaQuantities[i].areacode}: {props.areaQuantities[i].areaname}
                        </Text>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "updDateF"} style={productCSS.gridShort}>
                        <View style={productCSS.textEdit}>
                            <Pressable style={productCSS.buttonUpdate} onPress={() => updateData(i)}>
                                <View style={productCSS.text}><Text>EDIT</Text></View>
                            </Pressable>
                        </View>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "delete"} style={productCSS.gridShort}>
                        <Text>
                            <Pressable style={productCSS.button} onPress={() => deleteData(i)}>
                                <Text style={productCSS.text}>DELETE</Text>
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
