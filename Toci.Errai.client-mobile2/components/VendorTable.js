import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput } from 'react-native'
import { DataTable } from 'react-native-paper'
import { Picker } from '@react-native-community/picker'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
export default function VendorTable() {

    const [mySelectedData, setmySelectedData] = useState({
        vendor: null,
        type: null,
        price: 0,
    })

    const [vendorData, setvendorData] = useState(['Bartosz', 'Marek', 'hujmuj'])
    const [types, settypes] = useState(['$/m', 'h/kg', 'm2/kg', 'sasin/h'])

    const setVendorsFunc = (itemValue) => {
        console.log(itemValue)
    }

    const setcountTypesFunc = (itemValue) => {
        console.log(itemValue)
    }

    const setValueFunc = (e) => {
        console.log(e.target.value)
        let x = e.target.value

        setmySelectedData(prev => {
            return {...prev,
                price: x}
        })

    }




    const ok = () => {
        console.log('OK');
        console.log(mySelectedData);
    }

    return (
        <View>
            <View>
                <View style={worksheetRecord.vendorContainer}>

                    <View style={worksheetRecord.vendorColumn}>

                        <Picker style={worksheetRecord.ComboPicker}
                            onValueChange={(itemValue, itemIndex) => setVendorsFunc(itemValue, itemIndex)}>

                            {
                                vendorData.map( (item, index) => {
                                    return <Picker.Item style={worksheetRecord.CombiItem} key={index} label={item} value={item} />
                                } )
                            }


                        </Picker>

                    </View>
                    <View style={worksheetRecord.vendorColumn}>

                        <Picker style={worksheetRecord.ComboPicker}
                            onValueChange={(itemValue, itemIndex) => setcountTypesFunc(itemValue, itemIndex)}>

                            {
                                types.map( (item, index) => {
                                    return <Picker.Item style={worksheetRecord.CombiItem} key={index} label={item} value={item} />
                                } )
                            }

                        </Picker>

                    </View>
                    <View style={worksheetRecord.vendorColumn}>
                        <TextInput
                            style={worksheetRecord.vendorColumnInput}
                            value={vendorData.price}
                            onChange={($event) =>  setValueFunc($event) }
                            placeholder="Amount"
                        />
                    </View>
                    <View style={worksheetRecord.vendorColumn}>
                        <Text style={worksheetRecord.vendorColumnOK}
                                onPress={ () => ok() }>
                            OK
                        </Text>
                    </View>

                </View>
            </View>
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
