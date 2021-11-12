import React from 'react'
import { Text, View } from 'react-native'
import { productDetails as pd } from '../../styles/productDetails'


export default function ProductDetails(props) {
    return (
        <View style={{marginTop: 10, marginBottom: 5, marginLeft: 15}}>
            <View style={pd.inlineContainer}>
                <Text style={[pd.inlineItemDetails, pd.inlineItemLeftDetails, pd.smallSize]}>
                    Description:
                </Text>
                <Text style={[pd.inlineItemDetails, pd.inlineItemRightDetails, pd.smallSize]}>
                    { props.product?.description }
                </Text>
            </View>
            <View style={pd.inlineContainer}>
                <Text style={[pd.inlineItemDetails, pd.inlineItemLeftDetails, pd.smallSize]}>
                    Account Reference:
                </Text>
                <Text style={[pd.inlineItemDetails, pd.inlineItemRightDetails, pd.smallSize]}>
                    { props.product?.productaccountreference }
                </Text>
            </View>
        </View>
    )
}
