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
        display: 'flex',
        flexDirection: 'row',
    },
    inlineItem: {
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
    },
    bold: {
        fontWeight: 'bold',
    },
    inlineItemLeftDetails: {
        width: '40%',
        display: 'flex',
        justifyContent: 'flex-end',
    },
    inlineItemRightDetails: {
        width: '60%',
        display: 'flex',
        justifyContent: 'flex-start',
    },
    inlineItemDetails: {
        display: 'flex',
        alignItems: 'center',
        paddingLeft: 4,
        paddingRight: 4,
        paddingTop: 8,
        paddingBottom: 8,
    },

})