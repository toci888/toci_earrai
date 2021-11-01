import React, { useState } from 'react'
import { Text, View, TextInput } from 'react-native'
import { Picker } from '@react-native-community/picker'
import { productCSS } from '../styles/productCSSStyles'
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
                <View style={productCSS.vendorContainer}>

                    <View style={productCSS.vendorColumn}>

                        <Picker style={productCSS.ComboPicker}
                            onValueChange={(itemValue, itemIndex) => setVendorsFunc(itemValue, itemIndex)}>

                            {
                                vendorData.map( (item, index) => {
                                    return <Picker.Item style={productCSS.CombiItem} key={index} label={item} value={item} />
                                } )
                            }


                        </Picker>

                    </View>
                    <View style={productCSS.vendorColumn}>

                        <Picker style={productCSS.ComboPicker}
                            onValueChange={(itemValue, itemIndex) => setcountTypesFunc(itemValue, itemIndex)}>

                            {
                                types.map( (item, index) => {
                                    return <Picker.Item style={productCSS.CombiItem} key={index} label={item} value={item} />
                                } )
                            }

                        </Picker>

                    </View>
                    <View style={productCSS.vendorColumn}>
                        <TextInput
                            style={productCSS.vendorColumnInput}
                            value={vendorData.price}
                            onChange={($event) =>  setValueFunc($event) }
                            placeholder="Amount"
                        />
                    </View>
                    <View style={productCSS.vendorColumn}>
                        <Text style={productCSS.vendorColumnOK}
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
