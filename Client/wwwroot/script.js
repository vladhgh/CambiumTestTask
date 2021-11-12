
function renderjQueryComponents() {



    $.ajax({
        'async': true,
        'type': "GET",
        'global': false,
        'dataType': 'json',
        'url': "https://localhost:44371/api/dots",
        'success': function (data) {

            var stage = new Konva.Stage({
                container: 'container',
                width: 1280,
                height: 720,
                offsetX: -50
            });

            console.log(data);

            var layer = new Konva.Layer();

            

            data.forEach(function (dot) {

                var group = new Konva.Group({
                    x: 0,
                    y: 0,
                    id: 'circle' + dot.id + 'group',
                });

                dot.comments.forEach(function (comment, i) {

                    var commentY = i == 0 ? dot.positionY + dot.radius : dot.positionY + dot.radius + 27.5 * (i);

                    var simpleText = new Konva.Text({
                        x: dot.positionX,
                        y: commentY,
                        text: comment.text,
                        fontSize: 14,
                        fontFamily: 'Calibri',
                        fill: 'green',
                        align: 'center',
                        offsetY: -10
                    });

                    simpleText.offsetX(simpleText.width() / 2);

                    var box = new Konva.Rect({
                        x: dot.positionX,
                        y: commentY,
                        width: simpleText.width() + 10,
                        height: simpleText.height() + 10,
                        fill: comment.backgroundColor,
                        stroke: 'darkgray',
                        strokeWidth: 2,
                        offsetY: -5
                    });

                    box.offsetX(box.width() / 2);

                    group.add(box);
                    group.add(simpleText);

                });

                var circle = new Konva.Circle({
                    id: 'circle' + dot.id,
                    x: dot.positionX,
                    y: dot.positionY,
                    radius: dot.radius,
                    fill: dot.color,
                });

                circle.on('dblclick dbltap',
                    function (crcl) {
                        var shape = stage.find('#' + crcl.target.attrs.id + 'group')[0];
                        //console.log('#' + crcl.target.attrs.id + 'group');
                        //console.log(shape);
                        shape.destroy();

                        $.ajax({
                            url: 'https://localhost:44371/api/dots/' + crcl.target.attrs.id.slice(-1),
                            type: 'DELETE',
                            dataType: 'text',                
                            success: function(result) {
                                console.log(result);
                            },
                            error: function(result) {
                                console.log(result);
                            }
                        });


                    });

                group.add(circle);
                layer.add(group);
            });
            
            stage.add(layer);
        }
    });
}