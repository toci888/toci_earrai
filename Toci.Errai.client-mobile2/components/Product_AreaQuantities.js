import React, { useState } from 'react'
import { DataTable } from 'react-native-paper'
import { globalStyles } from '../styles/globalStyles'
import { productCSS } from '../styles/Product_Util_Styles'
import { Alert, Text, View } from 'react-native'
import { TouchableOpacity } from 'react-native-gesture-handler'
import { deleteRequestParams, deleteUrl } from '../shared/RequestConfig'
import RestClient from '../shared/RestClient'


export default function Product_AreaQuantities(props) {

    let restClient = new RestClient();

    const deleteData = (index_) => {

        let x = props.areaQuantities[index_]
        // console.log(x)

        props.setloading(true)

        console.log("111111111111111111");
        console.log(deleteUrl(x['id']));
        console.log("1111111111111111112222222222222222222");
        console.log(deleteRequestParams(x['id']));

        restClient.DELETE(deleteUrl(x['id']), deleteRequestParams(x['id'])).then( x => {
            console.log("22222222222222222222222");
            // console.log(x);
            props.deleteProduct(index_);
            console.log("3333333333333333333333");
            Alert.alert("OK", "Area Quantity deleted", [ { onPress: () => console.log("OK") } ]);
            console.log("44444444444444444444444444");
        }).catch(error => {
            console.log(error);
            Alert.alert("Error", "Something went wrong",[ { onPress: () => console.log("OK") } ]);
        }).finally(data => {
            console.log("5555555555555555555555");
            props.setloading(false)
        });
        console.log("666666666666666666666666");
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
                        <Text>
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
                            <TouchableOpacity style={productCSS.buttonUpdate} onPress={() => updateData(i)}>
                                <Text style={productCSS.text}>EDIT</Text>
                            </TouchableOpacity>
                        </View>
                    </DataTable.Cell>
                    <DataTable.Cell key={i + "delete"} style={productCSS.gridShort}>
                        <Text>
                            <TouchableOpacity style={productCSS.button} onPress={() => {
                                Alert.alert("Delete", "Are you sure?", [
                                    {text:"Yes", onPress: () => deleteData(i)},
                                    {text:"No"}
                                ])
                            }}>
                                <Text style={productCSS.text}>DELETE</Text>
                            </TouchableOpacity>
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
