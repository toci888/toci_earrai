import React, { useEffect, useState } from 'react'
import { globalStyles } from '../styles/globalStyles'
import { Text, View, TextInput, ScrollView, Pressable } from 'react-native'
import { worksheetContentCSS } from '../styles/worksheetContent'
import { DataTable } from 'react-native-paper'
import { environment } from '../environment'
import { modalStyles } from '../styles/modalStyles'
import { worksheetRecord } from '../styles/worksheetRecordStyles'

let tempColumns = 3

export default function WorksheetContent({ route, navigation }) {

    const [connectService] = useState( navigation.getParam('connectService') )
    const [worksheetContent, setworksheetContent] = useState([])
    const [filteredValue, setfilteredValue] = useState("")
    const [loading, setloading] = useState(false)
    const [columns, setColumns] = useState([[],[]])
    const [apierror, setApierror] = useState(false)
    const [skipCounter, setSkipCounter] = useState(0)
    const [nomoredata, setNomoredata] = useState(false)

    useEffect(() => {
        connectService.setNowWorksheetId(navigation.getParam('worksheetId'))

        apiFetch()
    }, [])

    const apiFetch = () => {
        //const response = JSON.parse('[[{"id":9630,"idworksheet":4,"columnindex":0,"rowindex":0,"value":"GEng\\nCAT","createdat":"2021-09-07T21:38:42.664598","updatedat":"2021-09-07T21:38:42.664601","idworksheetNavigation":null},{"id":9631,"idworksheet":4,"columnindex":1,"rowindex":0,"value":"ProductRecord.AccountReference","createdat":"2021-09-07T21:38:42.759595","updatedat":"2021-09-07T21:38:42.759596","idworksheetNavigation":null},{"id":9632,"idworksheet":4,"columnindex":2,"rowindex":0,"value":"ProductRecord.Description","createdat":"2021-09-07T21:38:42.868672","updatedat":"2021-09-07T21:38:42.868673","idworksheetNavigation":null},{"id":9633,"idworksheet":4,"columnindex":3,"rowindex":0,"value":"SIZE","createdat":"2021-09-07T21:38:42.978","updatedat":"2021-09-07T21:38:42.978001","idworksheetNavigation":null},{"id":9634,"idworksheet":4,"columnindex":4,"rowindex":0,"value":"Std Length","createdat":"2021-09-07T21:38:43.076634","updatedat":"2021-09-07T21:38:43.076635","idworksheetNavigation":null},{"id":9635,"idworksheet":4,"columnindex":5,"rowindex":0,"value":"Std Width","createdat":"2021-09-07T21:38:43.227991","updatedat":"2021-09-07T21:38:43.227993","idworksheetNavigation":null},{"id":9636,"idworksheet":4,"columnindex":6,"rowindex":0,"value":"Column1","createdat":"2021-09-07T21:38:43.381151","updatedat":"2021-09-07T21:38:43.381152","idworksheetNavigation":null},{"id":9637,"idworksheet":4,"columnindex":7,"rowindex":0,"value":"Dimensions LxW","createdat":"2021-09-07T21:38:43.490181","updatedat":"2021-09-07T21:38:43.490182","idworksheetNavigation":null},{"id":9638,"idworksheet":4,"columnindex":8,"rowindex":0,"value":"Qty.","createdat":"2021-09-07T21:38:43.594614","updatedat":"2021-09-07T21:38:43.594615","idworksheetNavigation":null},{"id":9639,"idworksheet":4,"columnindex":9,"rowindex":0,"value":"Area","createdat":"2021-09-07T21:38:43.687838","updatedat":"2021-09-07T21:38:43.687838","idworksheetNavigation":null},{"id":9640,"idworksheet":4,"columnindex":10,"rowindex":0,"value":"Dimensions LxW2","createdat":"2021-09-07T21:38:43.793431","updatedat":"2021-09-07T21:38:43.793432","idworksheetNavigation":null},{"id":9641,"idworksheet":4,"columnindex":11,"rowindex":0,"value":"Qty2","createdat":"2021-09-07T21:38:43.885594","updatedat":"2021-09-07T21:38:43.885595","idworksheetNavigation":null},{"id":9642,"idworksheet":4,"columnindex":12,"rowindex":0,"value":"Area2","createdat":"2021-09-07T21:38:43.992171","updatedat":"2021-09-07T21:38:43.992172","idworksheetNavigation":null},{"id":9643,"idworksheet":4,"columnindex":13,"rowindex":0,"value":"Total Sq Metres","createdat":"2021-09-07T21:38:44.086934","updatedat":"2021-09-07T21:38:44.086935","idworksheetNavigation":null},{"id":9644,"idworksheet":4,"columnindex":14,"rowindex":0,"value":"Stock Take Value","createdat":"2021-09-07T21:38:44.260681","updatedat":"2021-09-07T21:38:44.260682","idworksheetNavigation":null},{"id":9645,"idworksheet":4,"columnindex":15,"rowindex":0,"value":"Cost \\n£ / SHEET","createdat":"2021-09-07T21:38:44.527053","updatedat":"2021-09-07T21:38:44.527054","idworksheetNavigation":null},{"id":9646,"idworksheet":4,"columnindex":16,"rowindex":0,"value":"Column2","createdat":"2021-09-07T21:38:44.696521","updatedat":"2021-09-07T21:38:44.696522","idworksheetNavigation":null},{"id":9647,"idworksheet":4,"columnindex":17,"rowindex":0,"value":"Add 30%","createdat":"2021-09-07T21:38:44.81128","updatedat":"2021-09-07T21:38:44.81128","idworksheetNavigation":null},{"id":9648,"idworksheet":4,"columnindex":18,"rowindex":0,"value":"35%","createdat":"2021-09-07T21:38:44.924796","updatedat":"2021-09-07T21:38:44.924797","idworksheetNavigation":null},{"id":9649,"idworksheet":4,"columnindex":19,"rowindex":0,"value":"40%","createdat":"2021-09-07T21:38:45.018617","updatedat":"2021-09-07T21:38:45.018617","idworksheetNavigation":null},{"id":9650,"idworksheet":4,"columnindex":20,"rowindex":0,"value":"50%","createdat":"2021-09-07T21:38:45.13194","updatedat":"2021-09-07T21:38:45.131941","idworksheetNavigation":null}],[{"id":9651,"idworksheet":4,"columnindex":0,"rowindex":1,"value":"","createdat":"2021-09-07T21:38:45.304733","updatedat":"2021-09-07T21:38:45.304733","idworksheetNavigation":null},{"id":9652,"idworksheet":4,"columnindex":1,"rowindex":1,"value":"","createdat":"2021-09-07T21:38:45.407563","updatedat":"2021-09-07T21:38:45.407563","idworksheetNavigation":null},{"id":9653,"idworksheet":4,"columnindex":2,"rowindex":1,"value":"","createdat":"2021-09-07T21:38:45.512188","updatedat":"2021-09-07T21:38:45.512189","idworksheetNavigation":null},{"id":9654,"idworksheet":4,"columnindex":3,"rowindex":1,"value":"Aluminium Plain","createdat":"2021-09-07T21:38:45.612789","updatedat":"2021-09-07T21:38:45.61279","idworksheetNavigation":null},{"id":9655,"idworksheet":4,"columnindex":4,"rowindex":1,"value":"Length","createdat":"2021-09-07T21:38:45.70628","updatedat":"2021-09-07T21:38:45.706281","idworksheetNavigation":null},{"id":9656,"idworksheet":4,"columnindex":5,"rowindex":1,"value":"Width","createdat":"2021-09-07T21:38:45.810663","updatedat":"2021-09-07T21:38:45.810664","idworksheetNavigation":null},{"id":9657,"idworksheet":4,"columnindex":6,"rowindex":1,"value":"Thickness","createdat":"2021-09-07T21:38:45.903142","updatedat":"2021-09-07T21:38:45.903143","idworksheetNavigation":null},{"id":9658,"idworksheet":4,"columnindex":7,"rowindex":1,"value":"Length x Width","createdat":"2021-09-07T21:38:46.006852","updatedat":"2021-09-07T21:38:46.006853","idworksheetNavigation":null},{"id":9659,"idworksheet":4,"columnindex":8,"rowindex":1,"value":"Qty.","createdat":"2021-09-07T21:38:46.100568","updatedat":"2021-09-07T21:38:46.100569","idworksheetNavigation":null},{"id":9660,"idworksheet":4,"columnindex":9,"rowindex":1,"value":"Area","createdat":"2021-09-07T21:38:46.305347","updatedat":"2021-09-07T21:38:46.305348","idworksheetNavigation":null},{"id":9661,"idworksheet":4,"columnindex":10,"rowindex":1,"value":"Length x Width","createdat":"2021-09-07T21:38:46.423968","updatedat":"2021-09-07T21:38:46.423969","idworksheetNavigation":null},{"id":9662,"idworksheet":4,"columnindex":11,"rowindex":1,"value":"Qty.","createdat":"2021-09-07T21:38:46.521623","updatedat":"2021-09-07T21:38:46.521624","idworksheetNavigation":null},{"id":9663,"idworksheet":4,"columnindex":12,"rowindex":1,"value":"Area","createdat":"2021-09-07T21:38:46.624132","updatedat":"2021-09-07T21:38:46.624134","idworksheetNavigation":null},{"id":9664,"idworksheet":4,"columnindex":13,"rowindex":1,"value":"m^2","createdat":"2021-09-07T21:38:46.718947","updatedat":"2021-09-07T21:38:46.718948","idworksheetNavigation":null},{"id":9665,"idworksheet":4,"columnindex":14,"rowindex":1,"value":"","createdat":"2021-09-07T21:38:46.817034","updatedat":"2021-09-07T21:38:46.817035","idworksheetNavigation":null},{"id":9666,"idworksheet":4,"columnindex":15,"rowindex":1,"value":"","createdat":"2021-09-07T21:38:46.922224","updatedat":"2021-09-07T21:38:46.922225","idworksheetNavigation":null},{"id":9667,"idworksheet":4,"columnindex":16,"rowindex":1,"value":"","createdat":"2021-09-07T21:38:47.019686","updatedat":"2021-09-07T21:38:47.019686","idworksheetNavigation":null},{"id":9668,"idworksheet":4,"columnindex":17,"rowindex":1,"value":"","createdat":"2021-09-07T21:38:47.14163","updatedat":"2021-09-07T21:38:47.141631","idworksheetNavigation":null},{"id":9669,"idworksheet":4,"columnindex":18,"rowindex":1,"value":"","createdat":"2021-09-07T21:38:47.363795","updatedat":"2021-09-07T21:38:47.363795","idworksheetNavigation":null},{"id":9670,"idworksheet":4,"columnindex":19,"rowindex":1,"value":"","createdat":"2021-09-07T21:38:47.504607","updatedat":"2021-09-07T21:38:47.504608","idworksheetNavigation":null},{"id":9671,"idworksheet":4,"columnindex":20,"rowindex":1,"value":"","createdat":"2021-09-07T21:38:47.5981","updatedat":"2021-09-07T21:38:47.598101","idworksheetNavigation":null}]]')
        //setColumns(response)
        //setloading(false)
        //return



        setloading(true)
        fetch(environment.prodApiUrl + "api/WorksheetContent/GetColumnsForWorksheet/" + navigation.getParam('worksheetId'))
        .then(response => response.json())
        .then(response => { setColumns(response); console.log(response); console.log(JSON.stringify(response)); })
        .catch(error => { setApierror(true) })
        .finally(() => { setloading(false) })
    }

    const searchForData = (filteredValue_, skipCounter_) => {
        //let response = JSON.parse('[[{"id":9672,"idworksheet":4,"columnindex":0,"rowindex":2,"value":"ALSH","createdat":"2021-09-07T21:38:47.722849","updatedat":"2021-09-07T21:38:47.72285","idworksheetNavigation":null},{"id":9673,"idworksheet":4,"columnindex":1,"rowindex":2,"value":"ALSH_0.9_2500_1250","createdat":"2021-09-07T21:38:47.81607","updatedat":"2021-09-07T21:38:47.816071","idworksheetNavigation":null},{"id":9674,"idworksheet":4,"columnindex":2,"rowindex":2,"value":"ALSH_0.9_2500_1250","createdat":"2021-09-07T21:38:47.92843","updatedat":"2021-09-07T21:38:47.92843","idworksheetNavigation":null},{"id":9675,"idworksheet":4,"columnindex":3,"rowindex":2,"value":"0.8mm PLAIN","createdat":"2021-09-07T21:38:48.020865","updatedat":"2021-09-07T21:38:48.020866","idworksheetNavigation":null},{"id":9676,"idworksheet":4,"columnindex":4,"rowindex":2,"value":"2500","createdat":"2021-09-07T21:38:48.141842","updatedat":"2021-09-07T21:38:48.141843","idworksheetNavigation":null},{"id":9677,"idworksheet":4,"columnindex":5,"rowindex":2,"value":"1250","createdat":"2021-09-07T21:38:48.317944","updatedat":"2021-09-07T21:38:48.317944","idworksheetNavigation":null},{"id":9678,"idworksheet":4,"columnindex":6,"rowindex":2,"value":"0.9","createdat":"2021-09-07T21:38:48.41018","updatedat":"2021-09-07T21:38:48.410181","idworksheetNavigation":null},{"id":9679,"idworksheet":4,"columnindex":7,"rowindex":2,"value":"1 x 2","createdat":"2021-09-07T21:38:48.511796","updatedat":"2021-09-07T21:38:48.511797","idworksheetNavigation":null},{"id":9680,"idworksheet":4,"columnindex":8,"rowindex":2,"value":"","createdat":"2021-09-07T21:38:48.612655","updatedat":"2021-09-07T21:38:48.612656","idworksheetNavigation":null},{"id":9681,"idworksheet":4,"columnindex":9,"rowindex":2,"value":"","createdat":"2021-09-07T21:38:48.71128","updatedat":"2021-09-07T21:38:48.711281","idworksheetNavigation":null},{"id":9682,"idworksheet":4,"columnindex":10,"rowindex":2,"value":"","createdat":"2021-09-07T21:38:48.814932","updatedat":"2021-09-07T21:38:48.814933","idworksheetNavigation":null},{"id":9683,"idworksheet":4,"columnindex":11,"rowindex":2,"value":"","createdat":"2021-09-07T21:38:48.909976","updatedat":"2021-09-07T21:38:48.909977","idworksheetNavigation":null},{"id":9684,"idworksheet":4,"columnindex":12,"rowindex":2,"value":"","createdat":"2021-09-07T21:38:49.008679","updatedat":"2021-09-07T21:38:49.00868","idworksheetNavigation":null},{"id":9685,"idworksheet":4,"columnindex":13,"rowindex":2,"value":"#VALUE!","createdat":"2021-09-07T21:38:49.101613","updatedat":"2021-09-07T21:38:49.101613","idworksheetNavigation":null},{"id":9686,"idworksheet":4,"columnindex":14,"rowindex":2,"value":"38","createdat":"2021-09-07T21:38:49.298388","updatedat":"2021-09-07T21:38:49.298388","idworksheetNavigation":null},{"id":9687,"idworksheet":4,"columnindex":15,"rowindex":2,"value":"#VALUE!","createdat":"2021-09-07T21:38:49.419471","updatedat":"2021-09-07T21:38:49.419471","idworksheetNavigation":null},{"id":9688,"idworksheet":4,"columnindex":16,"rowindex":2,"value":"","createdat":"2021-09-07T21:38:49.518365","updatedat":"2021-09-07T21:38:49.518365","idworksheetNavigation":null},{"id":9689,"idworksheet":4,"columnindex":17,"rowindex":2,"value":"","createdat":"2021-09-07T21:38:49.621123","updatedat":"2021-09-07T21:38:49.621124","idworksheetNavigation":null},{"id":9690,"idworksheet":4,"columnindex":18,"rowindex":2,"value":"","createdat":"2021-09-07T21:38:49.714568","updatedat":"2021-09-07T21:38:49.714569","idworksheetNavigation":null},{"id":9691,"idworksheet":4,"columnindex":19,"rowindex":2,"value":"","createdat":"2021-09-07T21:38:49.816003","updatedat":"2021-09-07T21:38:49.816004","idworksheetNavigation":null},{"id":9692,"idworksheet":4,"columnindex":20,"rowindex":2,"value":"","createdat":"2021-09-07T21:38:49.911706","updatedat":"2021-09-07T21:38:49.911707","idworksheetNavigation":null}],[{"id":9693,"idworksheet":4,"columnindex":0,"rowindex":3,"value":"ALSH","createdat":"2021-09-07T21:38:50.005031","updatedat":"2021-09-07T21:38:50.005032","idworksheetNavigation":null},{"id":9694,"idworksheet":4,"columnindex":1,"rowindex":3,"value":"ALSH_2_2500_1250","createdat":"2021-09-07T21:38:50.109306","updatedat":"2021-09-07T21:38:50.109306","idworksheetNavigation":null},{"id":9695,"idworksheet":4,"columnindex":2,"rowindex":3,"value":"ALSH_2_2500_1250","createdat":"2021-09-07T21:38:50.277299","updatedat":"2021-09-07T21:38:50.2773","idworksheetNavigation":null},{"id":9696,"idworksheet":4,"columnindex":3,"rowindex":3,"value":"2mm PLAIN","createdat":"2021-09-07T21:38:50.385346","updatedat":"2021-09-07T21:38:50.385347","idworksheetNavigation":null},{"id":9697,"idworksheet":4,"columnindex":4,"rowindex":3,"value":"2500","createdat":"2021-09-07T21:38:50.487208","updatedat":"2021-09-07T21:38:50.487209","idworksheetNavigation":null},{"id":9698,"idworksheet":4,"columnindex":5,"rowindex":3,"value":"1250","createdat":"2021-09-07T21:38:50.590155","updatedat":"2021-09-07T21:38:50.590156","idworksheetNavigation":null},{"id":9699,"idworksheet":4,"columnindex":6,"rowindex":3,"value":"2","createdat":"2021-09-07T21:38:50.684029","updatedat":"2021-09-07T21:38:50.68403","idworksheetNavigation":null},{"id":9700,"idworksheet":4,"columnindex":7,"rowindex":3,"value":"","createdat":"2021-09-07T21:38:50.825046","updatedat":"2021-09-07T21:38:50.825047","idworksheetNavigation":null},{"id":9701,"idworksheet":4,"columnindex":8,"rowindex":3,"value":"","createdat":"2021-09-07T21:38:50.924246","updatedat":"2021-09-07T21:38:50.924247","idworksheetNavigation":null},{"id":9702,"idworksheet":4,"columnindex":9,"rowindex":3,"value":"","createdat":"2021-09-07T21:38:51.024196","updatedat":"2021-09-07T21:38:51.024197","idworksheetNavigation":null},{"id":9703,"idworksheet":4,"columnindex":10,"rowindex":3,"value":"","createdat":"2021-09-07T21:38:51.133883","updatedat":"2021-09-07T21:38:51.133884","idworksheetNavigation":null},{"id":9704,"idworksheet":4,"columnindex":11,"rowindex":3,"value":"","createdat":"2021-09-07T21:38:51.398535","updatedat":"2021-09-07T21:38:51.398536","idworksheetNavigation":null},{"id":9705,"idworksheet":4,"columnindex":12,"rowindex":3,"value":"","createdat":"2021-09-07T21:38:51.529981","updatedat":"2021-09-07T21:38:51.529982","idworksheetNavigation":null},{"id":9706,"idworksheet":4,"columnindex":13,"rowindex":3,"value":"0","createdat":"2021-09-07T21:38:51.624634","updatedat":"2021-09-07T21:38:51.624635","idworksheetNavigation":null},{"id":9707,"idworksheet":4,"columnindex":14,"rowindex":3,"value":"0","createdat":"2021-09-07T21:38:51.729156","updatedat":"2021-09-07T21:38:51.729157","idworksheetNavigation":null},{"id":9708,"idworksheet":4,"columnindex":15,"rowindex":3,"value":"","createdat":"2021-09-07T21:38:51.822956","updatedat":"2021-09-07T21:38:51.822957","idworksheetNavigation":null},{"id":9709,"idworksheet":4,"columnindex":16,"rowindex":3,"value":"","createdat":"2021-09-07T21:38:51.926689","updatedat":"2021-09-07T21:38:51.92669","idworksheetNavigation":null},{"id":9710,"idworksheet":4,"columnindex":17,"rowindex":3,"value":"0","createdat":"2021-09-07T21:38:52.02045","updatedat":"2021-09-07T21:38:52.02045","idworksheetNavigation":null},{"id":9711,"idworksheet":4,"columnindex":18,"rowindex":3,"value":"0","createdat":"2021-09-07T21:38:52.147054","updatedat":"2021-09-07T21:38:52.147056","idworksheetNavigation":null},{"id":9712,"idworksheet":4,"columnindex":19,"rowindex":3,"value":"0","createdat":"2021-09-07T21:38:52.332729","updatedat":"2021-09-07T21:38:52.33273","idworksheetNavigation":null},{"id":9713,"idworksheet":4,"columnindex":20,"rowindex":3,"value":"0","createdat":"2021-09-07T21:38:52.435563","updatedat":"2021-09-07T21:38:52.435564","idworksheetNavigation":null}],[{"id":9735,"idworksheet":4,"columnindex":0,"rowindex":5,"value":"ALSH","createdat":"2021-09-07T21:38:54.921958","updatedat":"2021-09-07T21:38:54.921959","idworksheetNavigation":null},{"id":9736,"idworksheet":4,"columnindex":1,"rowindex":5,"value":"ALSH_3_2500_1250","createdat":"2021-09-07T21:38:55.015292","updatedat":"2021-09-07T21:38:55.015293","idworksheetNavigation":null},{"id":9737,"idworksheet":4,"columnindex":2,"rowindex":5,"value":"ALSH_3_2500_1250","createdat":"2021-09-07T21:38:55.133681","updatedat":"2021-09-07T21:38:55.133683","idworksheetNavigation":null},{"id":9738,"idworksheet":4,"columnindex":3,"rowindex":5,"value":"3mm PLAIN","createdat":"2021-09-07T21:38:55.299761","updatedat":"2021-09-07T21:38:55.299762","idworksheetNavigation":null},{"id":9739,"idworksheet":4,"columnindex":4,"rowindex":5,"value":"2500","createdat":"2021-09-07T21:38:55.41752","updatedat":"2021-09-07T21:38:55.41752","idworksheetNavigation":null},{"id":9740,"idworksheet":4,"columnindex":5,"rowindex":5,"value":"1250","createdat":"2021-09-07T21:38:55.526845","updatedat":"2021-09-07T21:38:55.526846","idworksheetNavigation":null},{"id":9741,"idworksheet":4,"columnindex":6,"rowindex":5,"value":"3","createdat":"2021-09-07T21:38:55.629445","updatedat":"2021-09-07T21:38:55.629446","idworksheetNavigation":null},{"id":9742,"idworksheet":4,"columnindex":7,"rowindex":5,"value":"","createdat":"2021-09-07T21:38:55.727944","updatedat":"2021-09-07T21:38:55.727945","idworksheetNavigation":null},{"id":9743,"idworksheet":4,"columnindex":8,"rowindex":5,"value":"","createdat":"2021-09-07T21:38:55.827605","updatedat":"2021-09-07T21:38:55.827606","idworksheetNavigation":null},{"id":9744,"idworksheet":4,"columnindex":9,"rowindex":5,"value":"","createdat":"2021-09-07T21:38:55.920807","updatedat":"2021-09-07T21:38:55.920808","idworksheetNavigation":null},{"id":9745,"idworksheet":4,"columnindex":10,"rowindex":5,"value":"","createdat":"2021-09-07T21:38:56.022611","updatedat":"2021-09-07T21:38:56.022612","idworksheetNavigation":null},{"id":9746,"idworksheet":4,"columnindex":11,"rowindex":5,"value":"","createdat":"2021-09-07T21:38:56.128316","updatedat":"2021-09-07T21:38:56.128317","idworksheetNavigation":null},{"id":9747,"idworksheet":4,"columnindex":12,"rowindex":5,"value":"","createdat":"2021-09-07T21:38:56.308741","updatedat":"2021-09-07T21:38:56.308742","idworksheetNavigation":null},{"id":9748,"idworksheet":4,"columnindex":13,"rowindex":5,"value":"0","createdat":"2021-09-07T21:38:56.412607","updatedat":"2021-09-07T21:38:56.412608","idworksheetNavigation":null},{"id":9749,"idworksheet":4,"columnindex":14,"rowindex":5,"value":"315","createdat":"2021-09-07T21:38:56.511878","updatedat":"2021-09-07T21:38:56.511878","idworksheetNavigation":null},{"id":9750,"idworksheet":4,"columnindex":15,"rowindex":5,"value":"#DIV/0!","createdat":"2021-09-07T21:38:56.636368","updatedat":"2021-09-07T21:38:56.636369","idworksheetNavigation":null},{"id":9751,"idworksheet":4,"columnindex":16,"rowindex":5,"value":"","createdat":"2021-09-07T21:38:56.743567","updatedat":"2021-09-07T21:38:56.743568","idworksheetNavigation":null},{"id":9752,"idworksheet":4,"columnindex":17,"rowindex":5,"value":"#DIV/0!","createdat":"2021-09-07T21:38:56.875882","updatedat":"2021-09-07T21:38:56.875883","idworksheetNavigation":null},{"id":9753,"idworksheet":4,"columnindex":18,"rowindex":5,"value":"#DIV/0!","createdat":"2021-09-07T21:38:56.976546","updatedat":"2021-09-07T21:38:56.976546","idworksheetNavigation":null},{"id":9754,"idworksheet":4,"columnindex":19,"rowindex":5,"value":"#DIV/0!","createdat":"2021-09-07T21:38:57.082946","updatedat":"2021-09-07T21:38:57.082947","idworksheetNavigation":null},{"id":9755,"idworksheet":4,"columnindex":20,"rowindex":5,"value":"#DIV/0!","createdat":"2021-09-07T21:38:57.231752","updatedat":"2021-09-07T21:38:57.231753","idworksheetNavigation":null}],[{"id":9756,"idworksheet":4,"columnindex":0,"rowindex":6,"value":"ALSH","createdat":"2021-09-07T21:38:57.365755","updatedat":"2021-09-07T21:38:57.365756","idworksheetNavigation":null},{"id":9757,"idworksheet":4,"columnindex":1,"rowindex":6,"value":"ALSH_4_2500_1250","createdat":"2021-09-07T21:38:57.467803","updatedat":"2021-09-07T21:38:57.467804","idworksheetNavigation":null},{"id":9758,"idworksheet":4,"columnindex":2,"rowindex":6,"value":"ALSH_4_2500_1250","createdat":"2021-09-07T21:38:57.572051","updatedat":"2021-09-07T21:38:57.572052","idworksheetNavigation":null},{"id":9759,"idworksheet":4,"columnindex":3,"rowindex":6,"value":"4mm PLAIN","createdat":"2021-09-07T21:38:57.666544","updatedat":"2021-09-07T21:38:57.666545","idworksheetNavigation":null},{"id":9760,"idworksheet":4,"columnindex":4,"rowindex":6,"value":"2500","createdat":"2021-09-07T21:38:57.77155","updatedat":"2021-09-07T21:38:57.77155","idworksheetNavigation":null},{"id":9761,"idworksheet":4,"columnindex":5,"rowindex":6,"value":"1250","createdat":"2021-09-07T21:38:57.866558","updatedat":"2021-09-07T21:38:57.866559","idworksheetNavigation":null},{"id":9762,"idworksheet":4,"columnindex":6,"rowindex":6,"value":"4","createdat":"2021-09-07T21:38:57.971001","updatedat":"2021-09-07T21:38:57.971003","idworksheetNavigation":null},{"id":9763,"idworksheet":4,"columnindex":7,"rowindex":6,"value":"","createdat":"2021-09-07T21:38:58.064634","updatedat":"2021-09-07T21:38:58.064635","idworksheetNavigation":null},{"id":9764,"idworksheet":4,"columnindex":8,"rowindex":6,"value":"","createdat":"2021-09-07T21:38:58.218749","updatedat":"2021-09-07T21:38:58.218751","idworksheetNavigation":null},{"id":9765,"idworksheet":4,"columnindex":9,"rowindex":6,"value":"","createdat":"2021-09-07T21:38:58.455693","updatedat":"2021-09-07T21:38:58.455694","idworksheetNavigation":null},{"id":9766,"idworksheet":4,"columnindex":10,"rowindex":6,"value":"","createdat":"2021-09-07T21:38:58.585299","updatedat":"2021-09-07T21:38:58.5853","idworksheetNavigation":null},{"id":9767,"idworksheet":4,"columnindex":11,"rowindex":6,"value":"","createdat":"2021-09-07T21:38:58.690334","updatedat":"2021-09-07T21:38:58.690335","idworksheetNavigation":null},{"id":9768,"idworksheet":4,"columnindex":12,"rowindex":6,"value":"","createdat":"2021-09-07T21:38:58.797708","updatedat":"2021-09-07T21:38:58.797709","idworksheetNavigation":null},{"id":9769,"idworksheet":4,"columnindex":13,"rowindex":6,"value":"0","createdat":"2021-09-07T21:38:58.897318","updatedat":"2021-09-07T21:38:58.897319","idworksheetNavigation":null},{"id":9770,"idworksheet":4,"columnindex":14,"rowindex":6,"value":"84","createdat":"2021-09-07T21:38:58.997609","updatedat":"2021-09-07T21:38:58.99761","idworksheetNavigation":null},{"id":9771,"idworksheet":4,"columnindex":15,"rowindex":6,"value":"#DIV/0!","createdat":"2021-09-07T21:38:59.091717","updatedat":"2021-09-07T21:38:59.091717","idworksheetNavigation":null},{"id":9772,"idworksheet":4,"columnindex":16,"rowindex":6,"value":"","createdat":"2021-09-07T21:38:59.280102","updatedat":"2021-09-07T21:38:59.280103","idworksheetNavigation":null},{"id":9773,"idworksheet":4,"columnindex":17,"rowindex":6,"value":"#DIV/0!","createdat":"2021-09-07T21:38:59.379356","updatedat":"2021-09-07T21:38:59.379357","idworksheetNavigation":null},{"id":9774,"idworksheet":4,"columnindex":18,"rowindex":6,"value":"#DIV/0!","createdat":"2021-09-07T21:38:59.486722","updatedat":"2021-09-07T21:38:59.486723","idworksheetNavigation":null},{"id":9775,"idworksheet":4,"columnindex":19,"rowindex":6,"value":"#DIV/0!","createdat":"2021-09-07T21:38:59.581287","updatedat":"2021-09-07T21:38:59.581288","idworksheetNavigation":null},{"id":9776,"idworksheet":4,"columnindex":20,"rowindex":6,"value":"#DIV/0!","createdat":"2021-09-07T21:38:59.685993","updatedat":"2021-09-07T21:38:59.685993","idworksheetNavigation":null}],[{"id":9777,"idworksheet":4,"columnindex":0,"rowindex":7,"value":"ALSH","createdat":"2021-09-07T21:38:59.78014","updatedat":"2021-09-07T21:38:59.780141","idworksheetNavigation":null},{"id":9778,"idworksheet":4,"columnindex":1,"rowindex":7,"value":"ALSH_5_2500_1250","createdat":"2021-09-07T21:38:59.885819","updatedat":"2021-09-07T21:38:59.88582","idworksheetNavigation":null},{"id":9779,"idworksheet":4,"columnindex":2,"rowindex":7,"value":"ALSH_5_2500_1250","createdat":"2021-09-07T21:38:59.980358","updatedat":"2021-09-07T21:38:59.980359","idworksheetNavigation":null},{"id":9780,"idworksheet":4,"columnindex":3,"rowindex":7,"value":"5mm Plain","createdat":"2021-09-07T21:39:00.139187","updatedat":"2021-09-07T21:39:00.139189","idworksheetNavigation":null},{"id":9781,"idworksheet":4,"columnindex":4,"rowindex":7,"value":"2500","createdat":"2021-09-07T21:39:00.357402","updatedat":"2021-09-07T21:39:00.357404","idworksheetNavigation":null},{"id":9782,"idworksheet":4,"columnindex":5,"rowindex":7,"value":"1250","createdat":"2021-09-07T21:39:00.532608","updatedat":"2021-09-07T21:39:00.532609","idworksheetNavigation":null},{"id":9783,"idworksheet":4,"columnindex":6,"rowindex":7,"value":"5","createdat":"2021-09-07T21:39:00.626395","updatedat":"2021-09-07T21:39:00.626396","idworksheetNavigation":null},{"id":9784,"idworksheet":4,"columnindex":7,"rowindex":7,"value":"","createdat":"2021-09-07T21:39:00.74097","updatedat":"2021-09-07T21:39:00.74097","idworksheetNavigation":null},{"id":9785,"idworksheet":4,"columnindex":8,"rowindex":7,"value":"","createdat":"2021-09-07T21:39:00.835337","updatedat":"2021-09-07T21:39:00.835338","idworksheetNavigation":null},{"id":9786,"idworksheet":4,"columnindex":9,"rowindex":7,"value":"","createdat":"2021-09-07T21:39:00.940019","updatedat":"2021-09-07T21:39:00.94002","idworksheetNavigation":null},{"id":9787,"idworksheet":4,"columnindex":10,"rowindex":7,"value":"","createdat":"2021-09-07T21:39:01.034801","updatedat":"2021-09-07T21:39:01.034802","idworksheetNavigation":null},{"id":9788,"idworksheet":4,"columnindex":11,"rowindex":7,"value":"","createdat":"2021-09-07T21:39:01.158421","updatedat":"2021-09-07T21:39:01.158422","idworksheetNavigation":null},{"id":9789,"idworksheet":4,"columnindex":12,"rowindex":7,"value":"","createdat":"2021-09-07T21:39:01.334572","updatedat":"2021-09-07T21:39:01.334573","idworksheetNavigation":null},{"id":9790,"idworksheet":4,"columnindex":13,"rowindex":7,"value":"0","createdat":"2021-09-07T21:39:01.428779","updatedat":"2021-09-07T21:39:01.428779","idworksheetNavigation":null},{"id":9791,"idworksheet":4,"columnindex":14,"rowindex":7,"value":"0","createdat":"2021-09-07T21:39:01.532586","updatedat":"2021-09-07T21:39:01.532587","idworksheetNavigation":null},{"id":9792,"idworksheet":4,"columnindex":15,"rowindex":7,"value":"","createdat":"2021-09-07T21:39:01.632706","updatedat":"2021-09-07T21:39:01.632707","idworksheetNavigation":null},{"id":9793,"idworksheet":4,"columnindex":16,"rowindex":7,"value":"","createdat":"2021-09-07T21:39:01.728618","updatedat":"2021-09-07T21:39:01.728619","idworksheetNavigation":null},{"id":9794,"idworksheet":4,"columnindex":17,"rowindex":7,"value":"0","createdat":"2021-09-07T21:39:01.830283","updatedat":"2021-09-07T21:39:01.830284","idworksheetNavigation":null},{"id":9795,"idworksheet":4,"columnindex":18,"rowindex":7,"value":"0","createdat":"2021-09-07T21:39:01.924248","updatedat":"2021-09-07T21:39:01.924248","idworksheetNavigation":null},{"id":9796,"idworksheet":4,"columnindex":19,"rowindex":7,"value":"0","createdat":"2021-09-07T21:39:02.047463","updatedat":"2021-09-07T21:39:02.047464","idworksheetNavigation":null},{"id":9797,"idworksheet":4,"columnindex":20,"rowindex":7,"value":"0","createdat":"2021-09-07T21:39:02.190475","updatedat":"2021-09-07T21:39:02.190477","idworksheetNavigation":null}]]')
        // setworksheetContent(prev => {
        //     return [...prev, ...response]
        // })
        // setloading(false)
        // return

        setloading(true)
        let x = environment.prodApiUrl + "api/WorksheetContent/searchWorksheet/"
                    + navigation.getParam('worksheetId') + "/" + filteredValue_ + "/" + skipCounter_
        console.log(x)
        fetch(x)
        .then(response => response.json())
        .then(response => {
            console.log(response)
            console.log(JSON.stringify(response))
            setSkipCounter(prev => prev + 1)
            setworksheetContent(prev => {
                return [...prev, ...response]
            })

            if(response.length == 0) {
                setNomoredata(true)
            }

        }).catch(error => {
            console.log(error)
        }).finally(x => {
            setloading(false)
        })
    }

    const loadMore = () => {
        if(!nomoredata) searchForData(filteredValue, skipCounter)
    }

    const showRecordData = (rowIndex) => {
        console.log(rowIndex);
        navigation.navigate('WorksheetRecord', {
            worksheetColumns: columns,
            rowIndex: rowIndex,
            workSheetRecord: worksheetContent[rowIndex],
            connectService: connectService
        })
    }

    const filterContent = () => {
        setworksheetContent(prev => {return []})
        setNomoredata(prev => {return false})
        setSkipCounter(prev => {return 0})

        searchForData(filteredValue, 0)
    }

    const setFilterText = (text) => {
        setfilteredValue(prev => {return text})
    }

    const reloadApp = () => {
        apiFetch()
    }

    if(apierror) return(
        <View>
            <View style={globalStyles.noConnectionView}>
                <Text style={globalStyles.noConnectionText}> NO CONNECTION </Text>
            </View>

            <View style={globalStyles.reloadView}>
                <Text onPress={reloadApp} style={globalStyles.reloadText}> RELOAD </Text>
            </View>

        </View>
    )

    return (
        <ScrollView style={globalStyles.content}>

            { loading && (
                <View style={modalStyles.tempContainer}>
                    <Text style={modalStyles.tempText}>Wait..</Text>
                </View>
            )}

            <View>
                <Text style={globalStyles.chooseWorkbookHeader}> Worksheet Content (Table) </Text>
            </View>

            <View style={worksheetContentCSS.filterContent}>
                <TextInput
                    value={filteredValue}
                    style={worksheetContentCSS.filterInput}
                    onChangeText={(text) => setFilterText(text)}
                    placeholder="Filter.."
                />
                <View style={worksheetContentCSS.filterButtonView}>
                    <Pressable style={worksheetContentCSS.filterButton} onPress={filterContent}>
                        <Text style={worksheetContentCSS.textUpdate}>Find</Text>
                    </Pressable>
                </View>

            </View>

            {/* <ScrollView> */}

                <View style={globalStyles.tableContainer}>

                    <DataTable.Header style={globalStyles.HalfHeader}>

                        {columns && columns[0]?.map((column, index) => {
                            if(index > tempColumns) return
                            return (
                                <DataTable.Title key={column.id} style={globalStyles.cell, {flex: 3}} > <Text>{column.value}</Text> </DataTable.Title>
                            )
                        })}

                    </DataTable.Header>

                    <DataTable.Header style={globalStyles.HalfHeader}>

                        {columns && columns[1]?.map((column, index) => {
                            if(index > tempColumns) return
                            return <DataTable.Title key={column.id} style={globalStyles.cell} > <Text>{column.value}</Text> </DataTable.Title>
                        })}

                    </DataTable.Header>

                    {
                        worksheetContent?.map( (row, rowIndex) => {
                            return(<DataTable.Row key={ rowIndex } style={worksheetContentCSS.customRow} >
                                { row.map( (column, columnIndex) => {
                                    if(columnIndex > tempColumns) return
                                    //console.log(column.id)
                                    return (
                                    <DataTable.Cell
                                        key={column.id}
                                        onPress={ () => showRecordData(rowIndex) }
                                        style={worksheetContentCSS.cell}>

                                        <Text>{column.value}</Text>
                                    </DataTable.Cell>)
                                } ) }
                            </DataTable.Row>)
                        } )
                    }

                </View>

            {/* </ScrollView> */}

            { nomoredata && (
                <View style={worksheetContentCSS.nomoredataView}>
                    <Text style={worksheetContentCSS.nomoredataText}>No more data</Text>
                </View>
            ) }

            { !nomoredata && worksheetContent.length > 0 && (
                <View style={worksheetContentCSS.loadMoreView}>
                    <Text onPress={loadMore} style={worksheetContentCSS.loadMoreText}>
                        Load more data
                    </Text>
                </View>
            ) }

        </ScrollView>
    )
}
