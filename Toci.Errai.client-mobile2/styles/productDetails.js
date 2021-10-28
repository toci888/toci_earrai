import { StyleSheet } from 'react-native';

export const productDetails = StyleSheet.create({

    container: {
        borderTopWidth: 2,
        borderColor: '#000000'
    },
    rowContainer: {
        width: '100%',
    },

    inlineContainer: {
        flexDirection: 'row',
    },
    inlineItem: {

        display: 'flex',
        alignItems: 'center',
        paddingLeft: 10,
        paddingRight: 10,
        paddingTop: 15,
        paddingBottom: 15,

    },
    inlineItemLeft: {
        width: '50%',
        display: 'flex',
        justifyContent: 'flex-end',

    },
    inlineItemRight: {
        width: '50%',
        display: 'flex',
        justifyContent: 'flex-start',
    },
    smallSize: {
        fontSize: 12,
    }



})