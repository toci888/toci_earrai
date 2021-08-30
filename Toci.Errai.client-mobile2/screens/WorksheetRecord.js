import React, { useEffect, useState } from 'react'
import { Button, Text, View, TextInput, Picker } from 'react-native'
import { animationFrames } from 'rxjs'
import { globalStyles } from '../styles/globalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'
import AsyncStorage from '@react-native-community/async-storage'

export default function WorksheetRecord({ route, navigation }) {

    const [connectService] = useState( navigation.getParam('connectService') )
    const [columnsName, setColumnsName] = useState([])
    const [columnsData, setColumnsData] = useState([])
    const [areas, setareas] = useState([])
    const [areaId, setareaId] = useState("")
    const [tempAreaquantity, settempAreaquantity] = useState("")
    const [codedimansions, setcodedimansions] = useState(null)
    const [kindOfDisplay, setkindOfDisplay] = useState(null)

    const [widthHook, setwidthHook] = useState("")
    const [lengthHook, setlengthHook] = useState("")

    useEffect( () => {

        console.log("USE EFFECT")

        connectService.setRowIndex(navigation.getParam('rowIndex') || null)

        setColumnsName(navigation.getParam('worksheetColumns'))
        const x = navigation.getParam('workSheetRecord')
        console.log('workSheetRecord');
        console.log(x);


        let code, code2;
        if(x == null) {
            const newArr = []
            for(let i=0; i < navigation.getParam('worksheetColumns')[0].length; i++) {
                newArr.push(
                    {
                        idworksheet: 1,
                        createdat: new Date().getTime(),
                        updatedat: new Date().getTime(),
                        columnindex: i,
                        rowindex: null
                    }
                )
            }
            setColumnsData(newArr)
        } else {
            let x = navigation.getParam('workSheetRecord')
            setColumnsData(x)
            console.log(x);

            code = x[0].value
            code2 = x[1].value

            console.log("code")
            console.log(code)
            console.log(code2)


            /*settempAreaquantity( prev => {
                return {...prev,
                    rowindex: navigation.getParam('workSheetRecord')[0].rowindex,
                    idcodesdimensions: 1 }
            })*/


        }


        Promise.all([
            AsyncStorage.getItem('Areas'),
            AsyncStorage.getItem('Categories'),
        ]).then( response => {
            let _areas = JSON.parse(response[0])
            let _categories = JSON.parse(response[1])
            console.log("areas");
            console.log(_areas)
            setareas(_areas)

            console.log("categories");
            console.log(_categories)

            let kind = _categories.filter(item => ((item.code).trim() == code2) || ((item.code).trim() == code))
            console.log(kind);
            kind = kind[0]['kind']
            setkindOfDisplay(kind)


            /*if(kind == 1) {
                // 2 inputy  width x length
            } else if(kind == 2) {
                // 1 input  length
            }*/




        } )




       /* AsyncStorage.getItem('Areas')
        .then(response => {
            response = JSON.parse(response)
            console.log("areas");
            console.log(response);
            setareas(prev => response)
            //return response
        })
        .then( () => {


            AsyncStorage.getItem('Categories')
            .then(response => {
                let x = JSON.parse(response)
                console.log("categories");
                console.log(x)
                let id = x.filter(it => it.code.includes(area))[0].id
                console.log(id);
                if(id > 5) {
                    settypeOfDisplay("TWO")
                } else {
                    settypeOfDisplay("ONE")
                }
                //setcategories(response)
            })


        })*/
        /*.AsyncStorage.getItem('Categories')
        .then( response => {
            console.log(response);
        } )*/

        return () => {console.log("END RECORD SCREEN ?")}
    }, [] )

    const testChangeValue = (e, index) => {
        console.log(e.target.value, index)


        let val = columnsData[index].value


        const tempContent = [...columnsData]

        //console.log(tempContent)

        tempContent[index].value = e.target.value



        setColumnsData(tempContent)
        return

    }

    const disconnect = () => {
        connectService.disconnect()
    }

    const updateValue = (index) => {

        const tempContent = columnsData[index]

        console.log(columnsData[index])
        if(!connectService.isConnectedFunc() ) {
            connectService.addDataToCache(tempContent)
        } else {
            connectService.updateRecord(tempContent)
        }
    }

    const setSelectedValue = (item, index) => {
        console.log(item)
        setarea(item)

    }

    const setLength = (e) => {
        console.log(e.target.value);
        setlengthHook(e.target.value)
    }

    const setWidth = (e) => {
        console.log(e.target.value);
        setwidthHook(e.target.value)
    }

    const setAreaquantity = (e) => {
        let quantity = e.target.value
        console.log(quantity)
        settempAreaquantity(quantity)
        /*if(!connectService.isConnectedFunc()) {
            connectService.addDataToCache(tempContent)
        } else {

        }*/





    }

    const valueOf = (value) => { return value == "" ? "Empty Value.." : value }

    const valueOfCol = (value) => { return value == "" ? "Empty Column" : value }


    const displayRow = () => {
        if(columnsName.length < 1) return

        let respo = []
        for(let i = 0; i < columnsData.length; i++) {

            respo.push(
                <View key={i} style={ worksheetRecord.rowContainer }>

                    <View style={worksheetRecord.columns}>
                        <View style={ worksheetRecord.listItem }>
                            <Text>{valueOfCol(columnsName[0][i].value)}</Text>
                        </View>

                        <View style={ worksheetRecord.listItem }>
                            <Text>{valueOfCol(columnsName[1][i].value)}</Text>
                        </View>
                    </View>

                    <View key={i + "x"} style={worksheetRecord.value}>
                        <Text>
                            {columnsData[i].value}
                            {/* <TextInput
                                style={worksheetRecord.inputStyle}
                                value={columnsData[i].value}
                                onChange={($event) => testChangeValue($event, i)}
                            /> */}

                        </Text>

                        {/* <Text style={worksheetRecord.updateButtonContainer}
                            onPress={ () => updateValue(i) }>
                            UPDATE
                        </Text> */}

                    </View>

                </View>
            )

            //respo.push()  style={{width: '85%'}}

        }

        return respo
    }

    return (
        <View style={worksheetRecord.container}>
            <View style={ worksheetRecord.absoluteUpdate }>
                <Text style={worksheetRecord.updateText} >
                    {navigation.getParam('rowIndex') == null ? "ADD NEW RECORD" : "UPDATE" }
                </Text>
            </View>
            <View>
                <Picker
                    selectedValue="Choose"
                    style={{ height: 50 }}
                    onValueChange={(itemValue, itemIndex) => setSelectedValue(itemValue, itemIndex)}>
                    {
                        areas.map( (item, index) => {
                            return <Picker.Item key={index} label={item.name} value={item.code} />
                        } )
                    }

                </Picker>
            </View>

            <View>


                    {
                        kindOfDisplay == 1 ?
                        (<View>

                            <Text>
                                <Text>width</Text>
                                <TextInput
                                    style={worksheetRecord.inputStyle}
                                    value={widthHook}
                                    onChange={($event) => setWidth($event)}
                                />

                            </Text>

                            <Text>
                                <Text>length</Text>
                                <TextInput
                                    style={worksheetRecord.inputStyle}
                                    value={lengthHook}
                                    onChange={($event) => setLength($event)}
                                />

                            </Text>

                        </View>)
                        :
                        (<Text>
                            <Text>length</Text>
                            <TextInput
                                style={worksheetRecord.inputStyle}
                                value={lengthHook}
                                onChange={($event) => setLength($event)}
                            />

                        </Text>)
                    }


            </View>
            <View>
                <Text>Quantity</Text>
                <Text>
                    <TextInput
                        style={worksheetRecord.inputStyle}
                        value={tempAreaquantity}
                        onChange={($event) => setAreaquantity($event)}
                    />

                </Text>


            </View>

            {/* <View style={globalStyles.header}>
                <Text onPress={ () => disconnect() }> !!! DISCONNECT !!!</Text>
            </View> */}
            <View>

                { displayRow() }

            </View>
        </View>
    )
}
