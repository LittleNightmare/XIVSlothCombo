using System;
using System.Numerics;
using ImGuiNET;
using XIVSlothCombo.Services;

namespace XIVSlothCombo.Window.Tabs
{
    internal class Settings : ConfigWindow
    {
        internal static new void Draw()
        {
            ImGui.BeginChild("main", new Vector2(0, 0), true);
            ImGui.Text("这个选项卡可以在启用功能时定制你的选项。");

            #region SubCombos

            bool hideChildren = Service.Configuration.HideChildren;

            if (ImGui.Checkbox("隐藏子选项", ref hideChildren))
            {
                Service.Configuration.HideChildren = hideChildren;
                Service.Configuration.Save();
            }

            if (ImGui.IsItemHovered())
            {
                ImGui.BeginTooltip();
                ImGui.TextUnformatted("隐藏所有已禁用功能的子选项。");
                ImGui.EndTooltip();
            }
            ImGui.NextColumn();

            #endregion

            #region Conflicting

            bool hideConflicting = Service.Configuration.HideConflictedCombos;
            if (ImGui.Checkbox("隐藏冲突功能", ref hideConflicting))
            {
                Service.Configuration.HideConflictedCombos = hideConflicting;
                Service.Configuration.Save();
            }

            if (ImGui.IsItemHovered())
            {
                ImGui.BeginTooltip();
                ImGui.TextUnformatted("隐藏所有与已启用功能冲突的功能。");
                ImGui.EndTooltip();
            }

            #endregion

            #region ForceDoubleWeave

            bool onlyDoubleWeave = Service.Configuration.OnlyDoubleWeave;

            if (ImGui.Checkbox("只双插", ref onlyDoubleWeave))
            {
                Service.Configuration.OnlyDoubleWeave = onlyDoubleWeave;
                Service.Configuration.Save();
            }

            if (ImGui.IsItemHovered())
            {
                ImGui.BeginTooltip();
                ImGui.TextUnformatted("启用后，插件不会在双插后，继续在循环中插入能力技。");
                ImGui.EndTooltip();
            }
            ImGui.NextColumn();
            #endregion

            #region Combat Log

            bool showCombatLog = Service.Configuration.EnabledOutputLog;

            if (ImGui.Checkbox("日志输出到聊天框", ref showCombatLog))
            {
                Service.Configuration.EnabledOutputLog = showCombatLog;
                Service.Configuration.Save();
            }

            if (ImGui.IsItemHovered())
            {
                ImGui.BeginTooltip();
                ImGui.TextUnformatted("把你对插件的操作实时输出到聊天框中");
                ImGui.EndTooltip();
            }
            #endregion

            #region SpecialEvent

            bool isSpecialEvent = DateTime.Now.Day == 1 && DateTime.Now.Month == 4;
            bool slothIrl = isSpecialEvent && Service.Configuration.SpecialEvent;

            if (isSpecialEvent)

            {

                if (ImGui.Checkbox("Sloth Mode!?", ref slothIrl))
                {
                    Service.Configuration.SpecialEvent = slothIrl;
                    Service.Configuration.Save();
                }
            }

            else
            {
                Service.Configuration.SpecialEvent = false;
                Service.Configuration.Save();
            }

            float offset = (float)Service.Configuration.MeleeOffset;
            ImGui.PushItemWidth(75);

            bool inputChangedeth = false;
            inputChangedeth |= ImGui.InputFloat("近战距离偏移量", ref offset);

            if (inputChangedeth)
            {
                Service.Configuration.MeleeOffset = (double)offset;
                Service.Configuration.Save();
            }

            if (ImGui.IsItemHovered())
            {
                ImGui.BeginTooltip();
                ImGui.TextUnformatted("如果不想 BOSS 稍微走出近战范围就立即使用远程攻击，那么可以对有近战距离检查的功能设置一个偏移量。");
                ImGui.EndTooltip();
            }

            #endregion

            #region Message of the Day

            bool motd = Service.Configuration.HideMessageOfTheDay;

            if (ImGui.Checkbox("关闭\"今日消息\"", ref motd))
            {
                Service.Configuration.HideMessageOfTheDay = motd;
                Service.Configuration.Save();
            }

            if (ImGui.IsItemHovered())
            {
                ImGui.BeginTooltip();
                ImGui.TextUnformatted("禁用登录时聊天框中的\"今日消息\"。");
                ImGui.EndTooltip();
            }
            ImGui.NextColumn();

            #endregion


            #region 输出到聊天框


            var setOutChat = Service.Configuration.SetOutChat;

            //if (ImGui.Checkbox("Hide Message of the Day", ref motd))
            if (ImGui.Checkbox("" + "Set输出到聊天" + "", ref setOutChat))
            {
                Service.Configuration.SetOutChat = setOutChat;
                Service.Configuration.Save();
            }

            #endregion

            ImGui.EndChild();
        }
    }
}
