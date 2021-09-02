import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput } from 'react-native'
import { DataTable } from 'react-native-paper'
import { Picker } from '@react-native-community/picker'
export default function VendorTable() {

    const [valueHook, setvalueHook] = useState(0)
    const [vendorsHook, setvendorsHook] = useState([
        'Bartosz', 'Marek', 'hujmuj'
    ])

    const [countTypesHook, setcountTypesHook] = useState([
        '$/m', 'N*t', 'm2/kg', 'sasin/h'
    ])

    const setVendorsFunc = (itemValue) => {
        console.log(itemValue)
    }

    const setcountTypesFunc = (itemValue) => {
        console.log(itemValue)
    }

    /*{
        vendorsHook.map( (item, index) => {
            return <Picker.Item key={index} label={item} value={item} />
        } )
    } */

    return (
        <View>
            <View>
            <Picker
                style={{width: 85}}
                selectedValue="abc"
                onValueChange={(itemValue, itemIndex) => setVendorsFunc(itemValue, itemIndex)}>
                <Picker.Item  label="c" value="a" />
                <Picker.Item  label="dc" value="da" />

            </Picker>
            </View>
            <DataTable>

                <DataTable.Row>
                    <DataTable.Cell>
                            <Text>xxx</Text>
                    </DataTable.Cell>
                    <DataTable.Cell>
                        <Picker
                            style={{width: 85}}
                            selectedValue="abc"
                            onValueChange={(itemValue, itemIndex) => setcountTypesFunc(itemValue, itemIndex)}>
                            {
                                countTypesHook.map( (item, index) => {
                                    return <Picker.Item key={index} label={item} value={item} />
                                } )
                            }

                        </Picker>
                    </DataTable.Cell>
                    <DataTable.Cell>
                        <TextInput
                            value="0"
                            placeholder="Value.."
                            onChange={ ($event) => filterWorkbooks($event) }
                        />
                    </DataTable.Cell>
                    <DataTable.Cell>
                        <TextInput
                            value="0"
                            placeholder="Value.."
                            onChange={ ($event) => filterWorkbooks($event) }
                        />
                    </DataTable.Cell>
                </DataTable.Row>





            </DataTable>
        </View>
    )
}
