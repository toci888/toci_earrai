import { StyleSheet } from 'react-native';

export const productCSS = StyleSheet.create({
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
        display: 'flex',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
    },
    textEdit: {
        width: '100%',
    },
    rowContainerTop: {
        flexDirection: 'row',
        paddingLeft: 0,
        margin: 10
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
        width: '100%',
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
})