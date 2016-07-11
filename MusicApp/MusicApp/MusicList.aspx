<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MusicList.aspx.cs" Inherits="MusicApp.MusicList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.0.3.min.js"></script>
    <link type="text/css" href="Styles/main.css" rel="stylesheet" />
    <script type="text/javascript">


        function GetAllSongs() {
            ///<summary> Function to return default songs </summary>
            ///<returns> <returns>
            $.getJSON("api/music", function (d) {
                $('.ListSection').empty();

                $.each(d, function (key, val) {
                    var node = '<li class="List" onclick="DeleteById(' + val.ID + ')"><span class="imgPlay">▶</span><span class="txtSong">' + val.SongName + '</span><span class="btnClose">❌</span></li>';
                    $(node).appendTo($('.ListSection'));
                });
            })
        }


        function DeleteById(val) {
            /// <summary> Function to delete songs based on id </summary>
            /// <param name="id"> Id of song </param>
            /// <returns> Deletes the songs only if it is not of type 'isDefault' </returns>
            $.ajax({
                url: 'api/music/Remove',
                type: 'POST',
                dataType: 'JSON',
                contentType: "application/json",
                data: JSON.stringify(val),
                success: function (d) {
                    GetAllSongs();
                }
            });
        }


        function AddSong() {
            /// <summary> Function to add songs to db </summary>
            /// <returns> Adds song to db </returns>
            var name = $('#txtAddSongs').val();
            if (name != null && name != '') {
                $.ajax({
                    url: 'api/music/Add',
                    type: 'POST',
                    dataType: 'JSON',
                    contentType: "application/json",
                    data: JSON.stringify(name),
                    success: function (d) {
                        $('#txtAddSongs').text = '';
                        GetAllSongs();
                    }
                });
            }
        }

        $(document).ready(GetAllSongs);
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="addSongsSection">
            <input type="text" id="txtAddSongs" placeholder="Enter song name" />
            <button id="btnAddSongs" onclick="AddSong();"><span>&#43;</span>Add Song</button>
        </div>
        <div class="songList">
            <ul class="ListSection">
            </ul>
        </div>
    </form>
</body>
</html>
