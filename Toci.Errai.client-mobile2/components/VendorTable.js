import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput/*, Picker*/ } from 'react-native'
import { DataTable } from 'react-native-paper'

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



    return (
        <View>
            <DataTable>

                <DataTable.Row>
                    <DataTable.Cell>
                        {/* <Picker
                            selectedValue={vendorsHook[0]}
                            onValueChange={(itemValue, itemIndex) => setVendorsFunc(itemValue, itemIndex)}>
                            {
                                vendorsHook.map( (item, index) => {
                                    return <Picker.Item key={index} label={item} value={item} />
                                } )
                            }

                        </Picker> */}
                    </DataTable.Cell>
                    <DataTable.Cell>
                        {/* <Picker
                            selectedValue={countTypesHook[0]}
                            onValueChange={(itemValue, itemIndex) => setcountTypesFunc(itemValue, itemIndex)}>
                            {
                                countTypesHook.map( (item, index) => {
                                    return <Picker.Item key={index} label={item} value={item} />
                                } )
                            }

                        </Picker> */}
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
