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

                {/* <Picker>
                    <Picker.Item  label="c" value="a" />
                    <Picker.Item  label="dc" value="da" />

                </Picker> */}

                {/* <Picker
                    style={{width: 85}}
                    selectedValue="abc"
                    onValueChange={(itemValue, itemIndex) => setcountTypesFunc(itemValue, itemIndex)}>

                    {
                        countTypesHook.map( (item, index) => {
                            return <Picker.Item key={index} label={item} value={item} />
                        } )
                    }

                </Picker> */}

            </View>

            <View>

             <TextInput
                    value="0"
                    placeholder="Value.."
                    onChange={ ($event) => filterWorkbooks($event) }
                />

            </View>

        </View>
    )
}
