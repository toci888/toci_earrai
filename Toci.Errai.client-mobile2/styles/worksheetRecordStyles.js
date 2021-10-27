import { StyleSheet } from 'react-native';

export const worksheetRecord = StyleSheet.create({
    container: {
        flex: 1
    },
    item: {
        borderTopWidth: 12,
        borderTopColor: '#807373',
        flexDirection: 'row'
    },
    listItem: {
        backgroundColor: 'white',
        color: 'black',
        paddingTop: 15,
        paddingBottom: 15,
        textAlign: 'center',
    },
    inputStyle: {
        backgroundColor: '#ddd',
        borderColor: '#777',
        color: '#000',
        textAlign: 'center',
        letterSpacing: 0.5,
        paddingTop: 10,
        paddingBottom: 10,
        paddingLeft: 10,
        fontSize: 17,
        width: '100%',
    },
    updateButtonContainer: {
        width: '15%',
        height: '100%',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        backgroundColor: '#5c5b61',
        color: 'white',
    },
    updateButton: {
        display: 'flex',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
    },
    columns: {
        width: '60%',
    },
    value: {
        width: '40%',
        display: 'flex',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
    },
    grid: {
        width: '15%',
        display: 'flex',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
    },
    gridShort: {
        width: 40,
        display: 'flex',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
    },
    rowContainerTop: {
        flexDirection: 'row',
        //borderTopColor: 'black',
        //borderTopWidth: 1,
        paddingLeft: 0,
        margin: 10
        //paddingStart: 0
    },
    rowContainerBottom: {
        flexDirection: 'row',
        borderBottomColor: 'black',
        borderBottomWidth: 1,
        paddingLeft: 0,
        paddingStart: 0,
        marginBottom: 3,
        paddingBottom: 6,
    },
    ComboPicker: {
        height: 50,
        backgroundColor: '#c1c1d2',
        borderWidth: 1,
        borderColor: '#c7c7c7',
        paddingLeft: 10
    },
    ComboView: {
        marginTop: 5,
        marginBottom: 5,
        marginLeft: 15,
        marginRight: 15,

    },
    CombiItem: {
        backgroundColor: 'red',
        color: 'yellow'
    },
    DimensionsView: {
    },
    QuantityView: {
        marginLeft: 15,
        marginRight: 15,
    },
    DimensionsInputContainerTwo: {
        width: '100%',
        height: 45
    },
    DimensionsInputContainerOne: {
        width: '100%',
        height: 45
    },
    QuantityInputContainer: {
        width: '100%',
        //height: 50
    },
    dimensionsInput: {
        backgroundColor: 'white',
        width: '100%',
        display: 'flex',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
        textAlign: 'center',
        fontSize: 17
    },
    button: {
        alignItems: 'center',
        justifyContent: 'center',
        paddingVertical: 10,
        paddingHorizontal: 8,
        borderRadius: 4,
        elevation: 3,
        backgroundColor: '#ff0000',
    },
    buttonUpdate: {
        alignItems: 'center',
        justifyContent: 'center',
        paddingVertical: 10,
        paddingHorizontal: 8,
        borderRadius: 4,
        elevation: 3,
        backgroundColor: '#1ab736',
    },




    text: {
        fontSize: 13,
        lineHeight: 18,
        fontWeight: 'bold',
        letterSpacing: 0.25,
        color: 'white',
    },
    buttonUpdate: {
        alignItems: 'center',
        justifyContent: 'center',
        paddingVertical: 10,
        paddingHorizontal: 5,
        borderRadius: 4,
        elevation: 3,
        backgroundColor: '#1c4423',
    },
    textUpdate: {
        fontSize: 13,
        lineHeight: 18,
        fontWeight: 'bold',
        letterSpacing: 0.25,
        color: 'black',
    },
    vendorContainer: {
        flexDirection: 'row',
        display: 'flex',

    },
    vendorColumn: {
        padding: 5,
        width: '25%'
    },
    vendorColumnOK: {
        width: '100%',
        display: 'flex',
        height: 50,
        alignItems: 'center',
        justifyContent: 'center',
        textAlign: 'center',
        backgroundColor: '#9999cc',
        fontSize: 18
    },
    vendorColumnInput: {
        backgroundColor: '#dddde6',
        width: '100%',
        display: 'flex',
        height: 50,
        alignItems: 'center',
        justifyContent: 'center',
        textAlign: 'center',
        fontSize: 17
    },
    inputStyle: {
        backgroundColor: '#ddd',
        borderColor: '#777',
        color: '#000',
        letterSpacing: 0.5,
        paddingTop: 10,
        paddingBottom: 10,
        fontSize: 17,
        paddingLeft: 15
    },

    inlineContainer: {
        flexDirection: 'row',
    },
    inlineItem: {

    }



})