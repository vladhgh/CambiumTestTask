function deleteDot(dotId, stage) {
    $.ajax({
        url: 'https://localhost:44371/api/dots/' + dotId,
        type: 'DELETE',
        dataType: 'text',
        success: function (result) {
            var shape = stage.find('#circle' + dotId + 'group')[0];
            shape.destroy();
        },
        error: function (result) {
            console.log(result);
        }
    });
}

function displayDot(dot, stage, layer) {
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

    //HANDLE DOUBLE CLICK EVENT AND DELETE DOT FROM SCREEN AND DB
    circle.on('dblclick dbltap',
        function (crcl) {
            deleteDot(crcl.target.attrs.id.slice(-1), stage);
        });

    group.add(circle);
    layer.add(group);
}

function displayDots(data) {

    var stage = new Konva.Stage({
        container: 'container',
        width: 1280,
        height: 720,
        offsetX: -50
    });

    var layer = new Konva.Layer();

    data.forEach(function (dot) {
        displayDot(dot, stage, layer);
    });

    stage.add(layer);
}

function loadDots() {

    $.ajax({
        url: 'https://localhost:44371/api/dots',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            displayDots(data);
        }
    });
}