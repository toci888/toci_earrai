import React from 'react'
import { worksheetRecordAddBtn } from '../styles/worksheetRecordAddBtnStyles'
import { Text, View } from 'react-native'
import { environment } from '../environment'
import { TouchableOpacity } from 'react-native-gesture-handler'
import { insertUrl, insertRequestInfo, updateRequestInfo, updateUrl } from './RequestData'

export default function WorksheetRecord_AddBtn(props) {

    const sendRequest = () => {
        let dataToSend = JSON.parse(JSON.stringify(props.tempAreaquantityRow));

        // TODO validate inputs
        props.setloading(true)
        if(props.btnvalueHook == "ADD") {

            fetch(insertUrl, insertRequestInfo(dataToSend)).then( response => {
                props.updateTableAfterRequest()
                props.initAreaQuantities()
            }).catch(error => {
                console.log(error)
            }).finally(x => {
                props.setloading(false)
            })

        } else if(props.btnvalueHook == "UPDATE") {

            fetch(updateUrl, updateRequestInfo(dataToSend)).then( response => {
                props.updateTableAfterRequest()
                props.initAreaQuantities()
            }).catch(error => {
                console.log(error)
            }).finally(x => {
                props.setloading(false)
            })
        }
    }


    const cancel = () => {
        props.setbtnvalueHook("ADD")
        props.initAreaQuantities()
    }



    return (
        <>
            <View style={ worksheetRecordAddBtn.absoluteUpdate }>
                <Text  onPress={ () => sendRequest()} style={worksheetRecordAddBtn.updateText}>
                    { props.btnvalueHook }
                </Text>
            </View>

            { props.btnvalueHook == "UPDATE" && (
                <View>
                    <View style={ worksheetRecordAddBtn.cancelBtn }>
                        <Text onPress={ () => cancel()} style={worksheetRecordAddBtn.deleteText}>
                            CANCEL
                        </Text>
                    </View>
                </View>
            ) }
        </>
    )
} {/* </TouchableOpacity> */} {/* </TouchableOpacity> */}