// Theme for echarts
var theme = {
    color: [
        '#26B99A', '#34495E', '#BDC3C7', '#3498DB',
        '#9B59B6', '#8abb6f', '#759c6a', '#bfd3b7'
    ],

    containLabel: true,

    title: {
        itemGap: 8,
        textStyle: {
            fontWeight: 'normal',
            color: '#408829'
        }
    },

    dataRange: {
        color: ['#1f610a', '#97b58d']
    },

    toolbox: {
        color: ['#408829', '#408829', '#408829', '#408829']
    },

    tooltip: {
        backgroundColor: 'rgba(0,0,0,0.5)',
        axisPointer: {
            type: 'line',
            lineStyle: {
                color: '#408829',
                type: 'dashed'
            },
            crossStyle: {
                color: '#408829'
            },
            shadowStyle: {
                color: 'rgba(200,200,200,0.3)'
            }
        }
    },

    dataZoom: {
        dataBackgroundColor: '#eee',
        fillerColor: 'rgba(64,136,41,0.2)',
        handleColor: '#408829'
    },
    grid: {
        borderWidth: 0
    },

    categoryAxis: {
        axisLine: {
            lineStyle: {
                color: '#408829'
            }
        },
        splitLine: {
            lineStyle: {
                color: ['#eee']
            }
        }
    },

    valueAxis: {
        axisLine: {
            lineStyle: {
                color: '#408829'
            }
        },
        splitArea: {
            show: true,
            areaStyle: {
                color: ['rgba(250,250,250,0.1)', 'rgba(200,200,200,0.1)']
            }
        },
        splitLine: {
            lineStyle: {
                color: ['#eee']
            }
        }
    },
    timeline: {
        lineStyle: {
            color: '#408829'
        },
        controlStyle: {
            normal: { color: '#408829' },
            emphasis: { color: '#408829' }
        }
    },

    k: {
        itemStyle: {
            normal: {
                color: '#68a54a',
                color0: '#a9cba2',
                lineStyle: {
                    width: 1,
                    color: '#408829',
                    color0: '#86b379'
                }
            }
        }
    },
    map: {
        itemStyle: {
            normal: {
                areaStyle: {
                    color: '#ddd'
                },
                label: {
                    textStyle: {
                        color: '#c12e34'
                    }
                }
            },
            emphasis: {
                areaStyle: {
                    color: '#99d2dd'
                },
                label: {
                    textStyle: {
                        color: '#c12e34'
                    }
                }
            }
        }
    },
    force: {
        itemStyle: {
            normal: {
                linkStyle: {
                    strokeColor: '#408829'
                }
            }
        }
    },
    chord: {
        padding: 4,
        itemStyle: {
            normal: {
                lineStyle: {
                    width: 1,
                    color: 'rgba(128, 128, 128, 0.5)'
                },
                chordStyle: {
                    lineStyle: {
                        width: 1,
                        color: 'rgba(128, 128, 128, 0.5)'
                    }
                }
            },
            emphasis: {
                lineStyle: {
                    width: 1,
                    color: 'rgba(128, 128, 128, 0.5)'
                },
                chordStyle: {
                    lineStyle: {
                        width: 1,
                        color: 'rgba(128, 128, 128, 0.5)'
                    }
                }
            }
        }
    },
    gauge: {
        startAngle: 225,
        endAngle: -45,
        axisLine: {
            show: true,
            lineStyle: {
                color: [[0.2, '#86b379'], [0.8, '#68a54a'], [1, '#408829']],
                width: 8
            }
        },
        axisTick: {
            splitNumber: 10,
            length: 12,
            lineStyle: {
                color: 'auto'
            }
        },
        axisLabel: {
            textStyle: {
                color: 'auto'
            }
        },
        splitLine: {
            length: 18,
            lineStyle: {
                color: 'auto'
            }
        },
        pointer: {
            length: '90%',
            color: 'auto'
        },
        title: {
            textStyle: {
                color: '#333'
            }
        },
        detail: {
            textStyle: {
                color: 'auto'
            }
        }
    },
    textStyle: {
        fontFamily: 'Arial, Verdana, sans-serif'
    }
};

// $(function () is shorthand notation for $(document).ready(function ()
// Exposure graph 1
$(function () {
    var json;
    try {        

        var echartLine = echarts.init(document.getElementById('exposure_graph'), theme);
        echartLine.setOption({
            title: {
                text: 'Line Graph',
                subtext: 'Subtitle'
            },
            tooltip: {
                trigger: 'axis'
            },
            legend: {
                x: 220,
                y: 40,
                data: ['Intent', 'Pre-order', 'Deal']
            },
            toolbox: {
                show: true,
                feature: {
                    magicType: {
                        show: true,
                        title: {
                            line: 'Line',
                            bar: 'Bar',
                            stack: 'Stack',
                            tiled: 'Tiled'
                        },
                        type: ['line', 'bar', 'stack', 'tiled']
                    },
                    restore: {
                        show: true,
                        title: "Restore"
                    },
                    saveAsImage: {
                        show: true,
                        title: "Save Image"
                    }
                }
            },
            calculable: true,
            xAxis: [{
                type: 'category',
                boundaryGap: false,
                data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
            }],
            yAxis: [{
                type: 'value'
            }],
            series: [{
                name: 'Deal',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal: {
                        areaStyle: {
                            type: 'default'
                        }
                    }
                },
                data: [10, 12, 21, 54, 260, 830, 710]
            }, {
                name: 'Pre-order',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal: {
                        areaStyle: {
                            type: 'default'
                        }
                    }
                },
                data: [30, 182, 434, 791, 390, 30, 10]
            }, {
                name: 'Intent',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal: {
                        areaStyle: {
                            type: 'default'
                        }
                    }
                },
                data: [1320, 1132, 601, 234, 120, 90, 20]
            }]
        });
    } catch (e) {
        // invalid json input, set to null
        json = null;
    }
});

// Exposure graph 2
$(function () {

    var name = GetDisplayName();
    var x = GetYearFrac();
    var y1 = GetExposureValues1();
    var y2 = GetExposureValues2();

    var json;
    try {
        

        var echartLine = echarts.init(document.getElementById('exposure_graph_dynamic'), theme);
        echartLine.setOption({
            title: {
                text: name,
                //subtext: 'Subtitle'
            },
            tooltip: {
                trigger: 'axis'
            },
            legend: {
                x: 220,
                y: 40,
                data: ['Swap EPE', 'Swap ENE'] //, 'Deal']
            },
            toolbox: {
                show: true,
                feature: {
                    magicType: {
                        show: true,
                        title: {
                            line: 'Line',
                            bar: 'Bar',
                            stack: 'Stack',
                            tiled: 'Tiled'
                        },
                        type: ['line', 'bar', 'stack', 'tiled']
                    },
                    restore: {
                        show: true,
                        title: "Restore"
                    },
                    saveAsImage: {
                        show: true,
                        title: "Save Image"
                    }
                }
            },
            calculable: true,
            xAxis: [{
                type: 'category',
                boundaryGap: false,
                data: x //['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
            }],
            yAxis: [{
                type: 'value'
            }],
            series: [{
                name: 'Swap EPE',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal: {
                        areaStyle: {
                            type: 'default'
                        }
                    }
                },
                data: y1 //[10, 12, 21, 54, 260, 830, 710]
            }, {
                name: 'Swap ENE',
                type: 'line',
                smooth: true,
                itemStyle: {
                    normal: {
                        areaStyle: {
                            type: 'default'
                        }
                    }
                },
                data: y2 //[30, 182, 434, 791, 390, 30, 10]
            //}, {
            //    name: 'Intent',
            //    type: 'line',
            //    smooth: true,
            //    itemStyle: {
            //        normal: {
            //            areaStyle: {
            //                type: 'default'
            //            }
            //        }
            //    },
            //    data: y //[1320, 1132, 601, 234, 120, 90, 20]
            }]
        });
    } catch (e) {
        // invalid json input, set to null
        json = null;
    }
});

// Exposure graph 3
//function LoadExposure() {

//    //y1 = [10, 12, 21, 54, 260, 830, 710];
//    //y2 = [30, 182, 434, 791, 390, 30, 10];
//    //y3 = [1320, 1132, 601, 234, 120, 90, 20];

//    var json;
//    try {

//        var test = GetData();
//        var y = [30, 182, 434, 791, 390, 30, 10];

//        var echartLine = echarts.init(document.getElementById('exposure_graph_dynamic'), theme);
//        echartLine.setOption({
//            title: {
//                text: 'Line Graph',
//                subtext: 'Subtitle'
//            },
//            tooltip: {
//                trigger: 'axis'
//            },
//            legend: {
//                x: 220,
//                y: 40,
//                data: ['Intent', 'Pre-order', 'Deal']
//            },
//            toolbox: {
//                show: true,
//                feature: {
//                    magicType: {
//                        show: true,
//                        title: {
//                            line: 'Line',
//                            bar: 'Bar',
//                            stack: 'Stack',
//                            tiled: 'Tiled'
//                        },
//                        type: ['line', 'bar', 'stack', 'tiled']
//                    },
//                    restore: {
//                        show: true,
//                        title: "Restore"
//                    },
//                    saveAsImage: {
//                        show: true,
//                        title: "Save Image"
//                    }
//                }
//            },
//            calculable: true,
//            xAxis: [{
//                type: 'category',
//                boundaryGap: false,
//                data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
//            }],
//            yAxis: [{
//                type: 'value'
//            }],
//            series: [{
//                name: 'Deal',
//                type: 'line',
//                smooth: true,
//                itemStyle: {
//                    normal: {
//                        areaStyle: {
//                            type: 'default'
//                        }
//                    }
//                },
//                data: y1 //[10, 12, 21, 54, 260, 830, 710]
//            }, {
//                name: 'Pre-order',
//                type: 'line',
//                smooth: true,
//                itemStyle: {
//                    normal: {
//                        areaStyle: {
//                            type: 'default'
//                        }
//                    }
//                },
//                data: y2 //[30, 182, 434, 791, 390, 30, 10]
//            }, {
//                name: 'Intent',
//                type: 'line',
//                smooth: true,
//                itemStyle: {
//                    normal: {
//                        areaStyle: {
//                            type: 'default'
//                        }
//                    }
//                },
//                data: y3 //[1320, 1132, 601, 234, 120, 90, 20]
//            }]
//        });
//    } catch (e) {
//        // invalid json input, set to null
//        json = null;
//    }
//};

// jQuery event handlers
$(document).ready(function () {
    $("#myAnc").click(function () {
        alert("Handler for .click() called.");
    });

    $("#settingsId").click(function () {
        // temp
        document.getElementById("div_1").innerHTML = 5000;        
    });

    $("#settingsId3").click(function () {
        document.getElementById("div_1").innerHTML = 7000;
    });
});

// Ordinary js function
function myFunction() {
    let d = new Date();
    document.getElementById("div_1").innerHTML = 1000;
    return true;
}

// Progress bar
function move() {
    var elem = document.getElementById("myBar");
    var msg = document.getElementById("progressbar");
    var width = 1;
    var id = setInterval(frame, 100);
    function frame() {
        if (width >= 100) {
            clearInterval(id);
        } else {
            width++;
            elem.style.width = width + '%';
            msg.innerHTML = width + '%';
        }
    }
}

// Misc graphing
var graphData = [{
    // Visits
    data: [[6, 1300], [7, 1600], [8, 1900], [9, 2100], [10, 2500], [11, 2200], [12, 2000], [13, 1950], [14, 1900], [15, 2000]],
    color: '#71c73e'
}, {
    // Returning Visits
    data: [[6, 500], [7, 600], [8, 550], [9, 600], [10, 800], [11, 900], [12, 800], [13, 850], [14, 830], [15, 1000]],
    color: '#77b7c5',
    points: { radius: 4, fillColor: '#77b7c5' }
}
];

$.plot($('#exposure_line'), graphData, {
    series: {
        points: {
            show: true,
            radius: 5
        },
        lines: {
            show: true
        },
        shadowSize: 0
    },
    grid: {
        color: '#646464',
        borderColor: 'transparent',
        borderWidth: 20,
        hoverable: true
    },
    xaxis: {
        tickColor: 'transparent',
        tickDecimals: 2
    },
    yaxis: {
        tickSize: 1000
    }
});

// Testing page loading
//$(document).ready(function () {
//    alert("document ready occurred 1");
//});

//$(document).ready(function () {
//    alert("document ready occurred 2");
//});

//$(document).ready(function () {
//    alert("document ready occurred 3");
//});

//$(window).load(function () {
//    alert("window load occurred!");
//});