import React from 'react'
import { Text, View } from 'react-native'
import { productDetails as pd } from '../styles/productDetails'


export default function Product_UtilTable(props) {

    let dictionary = new Map([
        ["poundsPerTonne", "£ per tonne"],
        ["poundsPerSheet", "£ per sheet"],
        ["poundsPerSquareMeter", "£ per square meter"],
        ["poundsPerLength", "£ per length"],
        ["kgPerMeter", "Kg per meter"],
        ["totalMeters", "Total meters"],
        ["stockTakeValue", "Stock Take Value"],
        ["kgPerSqrtMeter", "Kg per Sqrt Meter"],
        ["kgPerSheet", "Kg per sheet"],
        ["totalWeight", "Total weight"],
    ]);

    const x = (param) => {
        return dictionary.get(param)? dictionary.get(param) : param;
    }

    return (
        <View style={{marginBottom: 15}}>
            <View>
                <Text style={{padding: 15, fontSize: 17, width: '100%', textAlign: 'center'}}> {props.name} </Text>
            </View>
            {
                props.details && Object.keys(props.details).map( (value, key) => {
                    if(props.details[value] == null) return

                    // console.log(props)
                    // console.log(props.details[value])
                    // let dictionary = new Map([
                    //     ["£ per tonne"],
                    //     ["£ per sheet"],
                    //     ["£ per square meter"],
                    //     ["£ per length"],
                    // ]);
                    console.log("KONIEC4")
                    console.log(key); 
                    console.log(value); 
                    console.log(key, value); 
                    console.log(props.details); 
                    return (
                        <View key={key} style={pd.inlineContainer}>
                            <View style={[pd.inlineItem, pd.inlineItemLeft]}>
                                <Text style={{textAlign: 'right'}}>{x(value)}</Text>
                            </View>
                            <View style={[pd.inlineItem, pd.inlineItemRight]}>
                                <Text>{value.includes("pound")? "£ "+props.details[value] : props.details[value]}</Text>
                            </View>
                        </View>
                    )
                } )
            }
        </View>
    )
}
