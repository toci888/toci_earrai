import React, { useEffect, useState } from 'react'
import { Text, View } from 'react-native'
import AppUser from '../../shared/AppUser'
import Vendor_Inputs from './Vendors_Inputs'
import { Vendors_Styles as vs } from './Vendors_Styles'

export default function Vendors() {

    const [QuotesAndPricesHook, setQuotesAndPricesHook] = useState([])

    useEffect( () => {
        getAllQuotesAndPricesByProductId()
    }, [])

    const getAllQuotesAndPricesByProductId = async () => {
        const x = await AppUser.getAllQuotesAndPricesByProductId()
        console.log(x)
        setQuotesAndPricesHook(x)
    }

    return (
        <View>
            { QuotesAndPricesHook[0] &&
                <View style={vs.QPcontainer}>
                    <View style={[vs.VendorV, vs.columnsColors]}>
                        <Text> {Object.keys(QuotesAndPricesHook[0])[8] } </Text>
                    </View>
                    <View style={[vs.valuationV, vs.columnsColors]}>
                        <Text> {Object.keys(QuotesAndPricesHook[0])[7] } </Text>
                    </View>
                    <View style={[vs.priceV, vs.columnsColors]}>
                        <Text> {Object.keys(QuotesAndPricesHook[0])[3] } </Text>
                    </View>
                    <View style={[vs.initialsV, vs.columnsColors]}>
                        <Text> {Object.keys(QuotesAndPricesHook[0])[9] } </Text>
                    </View>
                </View>
            }

            { QuotesAndPricesHook.map( (v, k) => {
                return (
                    <View key={k} style={vs.QPcontainer}>

                        <View style={[vs.VendorV, vs.contentColors]}>
                            <Text> {v.vendor} </Text>
                        </View>
                        <View style={[vs.valuationV, vs.contentColors]}>
                            <Text> {v.valuation} </Text>
                        </View>
                        <View style={[vs.priceV, vs.contentColors]}>
                            <Text> {v.price} </Text>
                        </View>
                        <View style={[vs.initialsV, vs.contentColors]}>
                            <Text> {v.initials} </Text>
                        </View>

                    </View>
                )
            }) }

            <Vendor_Inputs
                getAllQuotesAndPricesByProductId={getAllQuotesAndPricesByProductId}
            />

        </View>

    )

}
