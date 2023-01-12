using OscJack;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace OscJack.VisualScripting {

[UnitCategory("OSC"), UnitTitle("OSC Output (Bang)")]
[RenamedFrom("Bolt.Addons.OscJack.OscBangOutput")]
public sealed class OscBangOutput : Unit
{
    #region Unit I/O

    [DoNotSerialize, PortLabelHidden]
    public ControlInput Enter { get; private set; }

    [DoNotSerialize]
    public ValueInput Connection { get; private set; }

    [DoNotSerialize]
    public ValueInput Address { get; private set; }

    [DoNotSerialize, PortLabelHidden]
    public ControlOutput Exit { get; private set; }

    #endregion

    #region Unit implementation

    protected override void Definition()
    {
        Enter = ControlInput(nameof(Enter), OnEnter);
        Exit = ControlOutput(nameof(Exit));
        Succession(Enter, Exit);

        Connection = ValueInput<OscConnection>(nameof(Connection), null);
        Address = ValueInput<string>(nameof(Address), "/unity");
    }

    ControlOutput OnEnter(Flow flow)
    {
        var connection = flow.GetValue<OscConnection>(Connection);
        if (connection == null) return Exit;

        var client = OscMaster.GetSharedClient(connection.host, connection.port);

        var address = flow.GetValue<string>(Address);
        client.Send(address);

        return Exit;
    }

    #endregion
}

} // namespace OscJack.VisualScripting
