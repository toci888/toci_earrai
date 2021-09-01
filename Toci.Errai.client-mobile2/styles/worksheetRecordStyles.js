import { StyleSheet } from 'react-native';

export const worksheetRecord = StyleSheet.create({
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
    container: {
        paddingTop: 40,
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
        width: '5%',
        display: 'flex',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
    },
    rowContainer: {
        flexDirection: 'row',
        borderBottomColor: 'black',
        borderBottomWidth: 1
    },
    absoluteUpdate: {
        position: 'absolute',
        top: 0,
        left: 0,
        width: '100%',
        height: 40,
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        backgroundColor: '#8781d8'
    },
    updateText: {
        fontWeight: 'bold',
        fontSize: 15
    },

    ComboPicker: {
        height: 50,
        backgroundColor: '#c1c1d2',
        borderWidth: 1,
        borderColor: '#c7c7c7',
        paddingLeft: 10
    },
    ComboView: {
        marginTop: 15,
        marginLeft: 15,
        marginRight: 15,
    },
    CombiItem: {
        backgroundColor: 'red',
        color: 'yellow'
    },


    DimensionsView: {
        flexDirection: 'row',
        display: 'flex'
    },
    DimensionsInputContainerTwo: {
        width: '50%',
        margin: 15,
        height: 50
    },
    DimensionsInputContainerTwo: {
        width: '100%',
        margin: 15,
        height: 50
    },
    QuantityInputContainer: {
        width: '100%',
        marginBottom: 15,
        marginLeft: 15,
        marginRight: 15,
        height: 50
    },
    dimensionsInput: {
        backgroundColor: 'white',
        width: '100%',
        display: 'flex',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
        placeholderTextColor: '#002db3',
        textAlign: 'center',
        fontSize: 17

    }

})