
function delete_post(id) {
    console.log(id)
    fetch("/admin/post/delete", {
        method: "POST",
        headers: {'Content-Type': 'application/json'}, 
        body: JSON.stringify({'id':id})
      }).then(res => {
        console.log(res);
        location.reload();
    });
};
document.getElementById("delete_all_posts").onclick = function() {
    alert()
    fetch("/admin/post/deleteall", {
        method: "POST",
        headers: {'Content-Type': 'application/json'}, 
      }).then(res => {
        console.log(res);
        location.reload();
    });
};

