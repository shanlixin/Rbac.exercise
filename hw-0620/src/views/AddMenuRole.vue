<template>
  <div>
    <el-tree
      :data="data"
      show-checkbox
      node-key="value"
      :default-expanded-keys="[1, 2, 5]"
      :props="defaultProps"
      ref="choosemenu"
    >
    </el-tree>
  </div>
</template>

<script>
export default {
  data() {
    return {
      data: [],
      defaultProps: {
        id: "value",
        children: "children",
        label: "label",
      },
    };
  },
  methods: {
    getlist() {
      this.$axios.get("Menu/GetList").then((d) => {
        var reg = new RegExp('\\,"children":\\[]', "g");
        this.data = JSON.parse(JSON.stringify(d.data).replace(reg, ""));
      });
    },
    getvalue() {
      var list = this.$refs.choosemenu
        .getCheckedNodes(true, true)
        .map((m) => m.value);
      console.log(list);
    },
  },
  created() {
    this.getlist();
  },
};
</script>