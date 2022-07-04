<template>
  <div>
    <el-select v-model="value" multiple placeholder="请选择">
      <el-option
        v-for="item in options"
        :key="item.roleId"
        :label="item.roleName"
        :value="item.roleId"
      >
      </el-option>
    </el-select>
  </div>
</template>

<script>
export default {
  data() {
    return {
      options: [],
      value: [],
    };
  },
  methods: {
    getrole() {
      this.$axios.get("Role/GetRoleAll").then((d) => {
        this.options = d.data;
      });
    },
  },
  created() {
    this.getrole();
  },
};
</script>